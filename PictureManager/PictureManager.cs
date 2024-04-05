using System;
using System.Collections.Generic;
using System.Text;
using WindowsLive.Writer.Api;
using System.Windows.Forms;

namespace PictureManager
{
    [WriterPlugin("662bc779-ee19-42a1-ae7b-1d73fa8fca82", "Manage Picture",
    Description = "An Windows Live Writer plugin, Manage picture. Created by Crifan.",
    HasEditableOptions = false,
    Name = "PictureManager",
    PublisherUrl = "http://www.crifan.com/",
    ImagePath = "PictureManager.ico")]
    [InsertableContentSource("PictureManager")]

    public class PictureManager : ContentSource
    {
        public PictureManager()
        {

        }

        public override DialogResult CreateContent(IWin32Window dialogOwner, ref string newContent)
        {
            using (frmPictureManager form = new frmPictureManager())
            {
                //store current selected content in WLW
                form.curSelectCotent = newContent;

                DialogResult result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    newContent = form.processedContent;
                }

                return result;
            }
        }
    }
}
