using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Xml;

namespace WMPToolBox
{
    public partial class MainForm : Form
    {

        private WMP m_WMP;

        public MainForm()
        {
            InitializeComponent();
            m_WMP = new WMP();
            if (!m_WMP.init())
                return;
        }

        private void Backup_Click(object sender, EventArgs e)
        {
            // choose file location
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.ShowDialog();
            string filePath = dlg.FileName;
            // backup library 
            m_WMP.backup(filePath);
        }

        private void Restore_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.ShowDialog();
            string filePath = dlg.FileName;
            m_WMP.restore(filePath);
        }
    }

    public class WMP
    {
        private WMPLib.WindowsMediaPlayer m_player;
        private IWMPMediaCollection m_media;
        private IWMPStringCollection m_albums;
        private IWMPStringCollection m_artists;

        public bool init()
        {
            m_player = new WMPLib.WindowsMediaPlayer();
            IWMPSettings2 settings = (IWMPSettings2)m_player.settings;
            bool b = settings.requestMediaAccessRights("read");
            if (!b)
                return b;
            m_media = m_player.mediaCollection;
            m_artists = m_media.getAttributeStringCollection("WM/AlbumArtist", "Audio");
            m_albums = m_media.getAttributeStringCollection("WM/AlbumTitle", "Audio");
            return true;
        }

        public void backup(string path)
        {
            XmlTextWriter writer = new XmlTextWriter(path, null);
            writer.Formatting = Formatting.Indented;

            writer.WriteStartDocument();

            writer.WriteStartElement("library");

            IWMPPlaylist allList =  m_media.getAll();
            int count = allList.count;
            for (int i = 0; i < count; ++i)
            {
                IWMPMedia mediaItem = allList.get_Item(i);
                string url = mediaItem.sourceURL;
                writer.WriteStartElement("MediaItem");
                writer.WriteAttributeString("url", url);

                int attCount = mediaItem.attributeCount;
                for (int j = 0; j < attCount; ++j)
                {
                    string attrName = mediaItem.getAttributeName(j);
                    writer.WriteStartElement(attrName);
                    string attrValue = mediaItem.getItemInfo(attrName);
                    writer.WriteAttributeString("value", attrValue);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
            writer.WriteEndDocument();
            writer.Close();
        }

        public void restore(string path)
        {
            XmlTextReader reader = new XmlTextReader(path);
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {

                }
            }
        }


    }
}
