using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.Web;

namespace PictureManager
{
    public partial class frmPictureManager : Form
    {
        public string curSelectCotent;
        public string processedContent;

        public crifanLib crifanLib;
        bool translatePicName = false;

        public frmPictureManager()
        {
            crifanLib = new crifanLib();

            InitializeComponent();
        }

        private void frmPictureManager_Load(object sender, EventArgs e)
        {
            this.Text += " v" + crifanLib.getCurVerStr();
        }

        private string generateNewFilename(string origFilename)
        {
            string newFilename = "";
            
            //replace all none-word to space
            Regex removeNoneWordP = new Regex(@"[^\w]+", RegexOptions.IgnoreCase);
            string onlyWordStr = removeNoneWordP.Replace(origFilename, " ");
            //strip leading and trailing space
            string afterTrimStr = onlyWordStr.Trim();
            //replace all space to _
            newFilename = afterTrimStr.Replace(' ', '_');
            newFilename = newFilename.ToLower();

            return newFilename;
        }

        private void commonProcessFunction()
        {
            processedContent = curSelectCotent;

            string wholeHref, hrefFullname, pointSuf, hrefPath, srcFullname, spaceTarget;
            string singlePicStr, newSinglePicStr;
            string realSrcFullname, srcFilename, decodedSrcFilename;
            string width, height;
            string widthHeight, newWidthHeight;
            int widthInt, heightInt;
            int srcFileWidth, srcFileHeight;
            int newWidth, newHeight;
            //int maxWidth = 640, maxHeight = 480;
            int maxWidth = 640;
            string wholeHrefWithTarget;
            string title, titleStr, altStr;

            //bool addTargetBlank = ckbTargetBlank.Checked;
            //bool translateZhcnName = ckbTransName.Checked;
            //bool autoScale = ckbAutoScale.Checked;

            //special is not thumb:
            //after replace:
            //<P><A 
            //href="file:///C:/Users/CLi/AppData/Local/Temp/WindowsLiveWriter2049324412/supfilesC93787/select-1st-cell-can-show-or-hidden_t.png" target="_blank"><IMG 
            //style="BACKGROUND-IMAGE: none; BORDER-RIGHT-WIDTH: 0px; MARGIN: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; DISPLAY: inline; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; PADDING-TOP: 0px" 
            //title="select 1st cell can show or hidden" border=0 
            //alt="select 1st cell can show or hidden" 
            //src="file:///C:/Users/CLi/AppData/Local/Temp/WindowsLiveWriter2049324412/supfilesC93787/select-1st-cell-can-show-or-hidden_t.png" 
            //width=414 height=1204></A></P>

            //string imgP = @"<A\s+?(?<wholeHref>href=""file:///(?<hrefFullname>(?<hrefPath>.+?WindowsLiveWriter\d+/supfiles\w+/).+?(?<pointSuf>\.\w{3,4}))""(?<spaceTarget>\s+?target="".+?"")?).*?>.+?src=""file:///(?<srcFullname>\k<hrefPath>(?<srcFilename>.+?)\k<pointSuf>)"".+?(?<widthHeight>width=(?<width>\d+)\s+?height=(?<height>\d+)).*?></A>";

            //<P><A 
            //href="file:///C:/Users/Administrator/AppData/Local/Temp/WindowsLiveWriter-1642303840/supfiles360FE7B/笑抽了 - 重口味的1楼和具有舍身精神的4楼[2].jpg"><IMG 
            //style="BACKGROUND-IMAGE: none; BORDER-RIGHT-WIDTH: 0px; PADDING-LEFT: 0px; PADDING-RIGHT: 0px; DISPLAY: inline; BORDER-TOP-WIDTH: 0px; BORDER-BOTTOM-WIDTH: 0px; BORDER-LEFT-WIDTH: 0px; PADDING-TOP: 0px" 
            //title="笑抽了 - 重口味的1楼和具有舍身精神的4楼" border=0 alt="笑抽了 - 重口味的1楼和具有舍身精神的4楼" 
            //src="file:///C:/Users/Administrator/AppData/Local/Temp/WindowsLiveWriter-1642303840/supfiles360FE7B/笑抽了 - 重口味的1楼和具有舍身精神的4楼_thumb.jpg" 
            //width=607 height=803></A></P>
            //string imgP = @"<A\s+?(?<wholeHref>href=""file:///(?<hrefFullname>(?<hrefPath>.+?WindowsLiveWriter-?\d+/supfiles\w+/).+?(?<pointSuf>\.\w{3,4}))""(?<spaceTarget>\s+?target="".+?"")?).*?>.+?src=""file:///(?<srcFullname>\k<hrefPath>(?<srcFilename>.+?)\k<pointSuf>)"".+?(?<widthHeight>width=(?<width>\d+)\s+?height=(?<height>\d+)).*?></A>";

            //title and alt
            //string imgP = @"<A\s+?(?<wholeHref>href=""file:///(?<hrefFullname>(?<hrefPath>.+?WindowsLiveWriter-?\d+/supfiles\w+/).+?(?<pointSuf>\.\w{3,4}))""(?<spaceTarget>\s+?target="".+?"")?).*?>.+?(?<title>title=""?.+?""?).+?(?<alt>alt=""?.+?""?)\s*src=""file:///(?<srcFullname>\k<hrefPath>(?<srcFilename>.+?)\k<pointSuf>)"".+?(?<widthHeight>width=(?<width>\d+)\s+?height=(?<height>\d+)).*?></A>";
            //string imgP = @"<A\s+?(?<wholeHref>href=""file:///(?<hrefFullname>(?<hrefPath>.+?WindowsLiveWriter-?\d+/supfiles\w+/).+?(?<pointSuf>\.\w{3,4}))""(?<spaceTarget>\s+?target="".+?"")?).*?>.+?(?<titleStr>title=""?(?<title>[^""]+)""?)\s+border=.+?(?<altStr>alt=""?\k<title>""?)\s+src=""file:///(?<srcFullname>\k<hrefPath>(?<srcFilename>.+?)\k<pointSuf>)"".+?(?<widthHeight>width=(?<width>\d+)\s+?height=(?<height>\d+)).*?></A>";

            //no border:
            //<P><A 
            //href="file:///C:/Users/Administrator/AppData/Local/Temp/WindowsLiveWriter-1642303840/supfiles383DC9A/监控拍下的小偷：大姐，您这一箱啤酒放哪儿了？[2].gif"><IMG 
            //style="DISPLAY: inline" title=监控拍下的小偷：大姐，您这一箱啤酒放哪儿了？ alt=监控拍下的小偷：大姐，您这一箱啤酒放哪儿了？ 
            //src="file:///C:/Users/Administrator/AppData/Local/Temp/WindowsLiveWriter-1642303840/supfiles383DC9A/监控拍下的小偷：大姐，您这一箱啤酒放哪儿了？_thumb.gif" 
            //width=234 height=165></A>&nbsp;</P>
            string imgP = @"<A\s+?(?<wholeHref>href=""file:///(?<hrefFullname>(?<hrefPath>.+?WindowsLiveWriter-?\d+/supfiles\w+/).+?(?<pointSuf>\.\w{3,4}))""(?<spaceTarget>\s+?target="".+?"")?).*?>.+?(?<titleStr>title=""?(?<title>[^""]+)""?)\s+(border=.+?\s+)?(?<altStr>alt=""?\k<title>""?)\s+src=""file:///(?<srcFullname>\k<hrefPath>(?<srcFilename>.+?)\k<pointSuf>)"".+?(?<widthHeight>width=(?<width>\d+)\s+?height=(?<height>\d+)).*?></A>";


            Regex imgRx = new Regex(imgP, RegexOptions.Singleline | RegexOptions.IgnoreCase);
            MatchCollection foundImg = imgRx.Matches(processedContent);

            if (foundImg.Count > 0)
            {
                foreach (Match found in foundImg)
                {
                    singlePicStr = found.Groups[0].ToString();
                    wholeHref = found.Groups["wholeHref"].Value;
                    hrefFullname = found.Groups["hrefFullname"].Value;
                    hrefPath = found.Groups["hrefPath"].Value;
                    spaceTarget = found.Groups["spaceTarget"].Value;
                    pointSuf = found.Groups["pointSuf"].Value;

                    titleStr = found.Groups["titleStr"].Value;
                    title = found.Groups["title"].Value;
                    altStr = found.Groups["altStr"].Value;

                    srcFullname = found.Groups["srcFullname"].Value;
                    srcFilename = found.Groups["srcFilename"].Value;

                    widthHeight = found.Groups["widthHeight"].Value;
                    width = found.Groups["width"].Value;
                    height = found.Groups["height"].Value;

                    widthInt = Int32.Parse(width);
                    heightInt = Int32.Parse(height);

                    newSinglePicStr = singlePicStr;

                    if (ckbTargetBlank.Checked)
                    {
                        //always set to target="_blank"
                        if (spaceTarget != "")
                        {
                            newSinglePicStr = newSinglePicStr.Replace(spaceTarget, " target=\"_blank\"");
                        }
                        else
                        {
                            wholeHrefWithTarget = wholeHref + " target=\"_blank\"";
                            newSinglePicStr = newSinglePicStr.Replace(wholeHref, wholeHrefWithTarget);
                        }
                    }

                    if (ckbReplaceHrefWithSr.Checked)
                    {
                        //replace src thumb addr to orgi href addr -> wlw will overwrite to new thumb
                        //processedContent = processedContent.Replace(srcFullname, hrefFullname);
                        //replace href addr to src thumb addr
                        newSinglePicStr = newSinglePicStr.Replace(hrefFullname, srcFullname);
                    }
                    
                    //check file exist or not, and find out the real full filename and filename
                    if (!System.IO.File.Exists(srcFullname))
                    {
                        realSrcFullname = HttpUtility.UrlDecode(srcFullname);
                        decodedSrcFilename = HttpUtility.UrlDecode(srcFilename);
                    }
                    else
                    {
                        realSrcFullname = srcFullname;
                        decodedSrcFilename = srcFilename;
                    }

                    if (ckbAutoScale.Checked)
                    {
                        Image img = Image.FromFile(realSrcFullname);
                        srcFileWidth = img.Width;
                        srcFileHeight = img.Height;

                        //here only scale according to width
                        if (srcFileWidth > maxWidth)
                        {
                            newWidth = maxWidth;
                            newHeight = newWidth * srcFileHeight / srcFileWidth;
                            newWidthHeight = "width=" + newWidth.ToString() + " height=" + newHeight.ToString();
                            newSinglePicStr = newSinglePicStr.Replace(widthHeight, newWidthHeight);
                        }
                    }
                                        
                    // try do translate filename
                    // after translate, replce src file name with new translated file name
                    if (translatePicName)
                    {
                        //extract filename for translate
                        string filenamePart = "", thumbPart = "";
                        // 1. normal include _thumb:
                        //王珞丹 22_thumb
                        //wangluodan   333_thumb[1]
                        // 2. special no name: 
                        //_thumb24
                        //_thumb22%5B1%5D -> _thumb22[1]
                        // 3. special not include _thumb: 
                        //select-1st-cell-can-show-or-hidden_t
                        //Regex srcFilenameRx = new Regex(@"(?<filenamePart>.*?)(?<thumbPart>_thumb[\[\d\]]*)?", RegexOptions.IgnoreCase);
                        Regex srcFilenameRx = new Regex(@"(?<filenamePart>.*)(?<thumbPart>_thumb[\[\d\]]*)?", RegexOptions.IgnoreCase);
                        Match foundSrcFilename = srcFilenameRx.Match(decodedSrcFilename);
                        if (foundSrcFilename.Success)
                        {
                            filenamePart = foundSrcFilename.Groups["filenamePart"].Value;
                            thumbPart = foundSrcFilename.Groups["thumbPart"].Value;
                            if ((thumbPart == "") && (filenamePart != ""))
                            {
                                Regex thumbInNameRx = new Regex(@"(?<filenamePart>.*?)(?<thumbPart>_thumb[\[\d\]]*)", RegexOptions.IgnoreCase);
                                Match foundThumbInName = thumbInNameRx.Match(filenamePart);
                                if (foundThumbInName.Success)
                                {
                                    filenamePart = foundThumbInName.Groups["filenamePart"].Value;
                                    thumbPart = foundThumbInName.Groups["thumbPart"].Value;
                                }
                            }
                        }

                        string filenamePartToTrans = "";
                        //check whether need translate
                        if (filenamePart == "")
                        {
                            //extract filename from title
                            //find title and alt, here must be contains title="xxx" and alt="xxx"
                            //title=彭德怀 border=0 alt=彭德怀

                            //string titleAltP = @"title=""?(?<title>[^""]+)""? border=.+?alt=""?\k<title>""?";
                            //Regex titleAltRx = new Regex(titleAltP);
                            //Match foundTitleAlt = titleAltRx.Match(singlePicStr);
                            //if (foundTitleAlt.Success)
                            //{
                            //    string title = foundTitleAlt.Groups["title"].Value;
                            //    if (title != "")
                            //    {
                            //        filenamePartToTrans = title;
                            //    }
                            //}

                            filenamePartToTrans = title;
                        }
                        else
                        {
                            //need translate
                            filenamePartToTrans = filenamePart;
                        }

                        // do translate
                        if (filenamePartToTrans != "")
                        {
                            string translatedFilenamePart = crifanLib.transZhcnToEn(filenamePartToTrans);
                            if (translatedFilenamePart != "")
                            {
                                //generate the new filename and fullFilename
                                string newFilenamePart = generateNewFilename(translatedFilenamePart);
                                string newSrcFilenameWithThumb = newFilenamePart + thumbPart;
                                string newSrcFilenameNoThumb = newFilenamePart;

                                string newSrcFullnameWithThumb = hrefPath + newSrcFilenameWithThumb + pointSuf;
                                string newSrcFullnameNoThumb = hrefPath + newSrcFilenameNoThumb + pointSuf;

                                //copy a new no thumb pic
                                System.IO.File.Copy(realSrcFullname, newSrcFullnameNoThumb);
                                //replace src with new filename
                                newSinglePicStr = newSinglePicStr.Replace(srcFullname, newSrcFullnameNoThumb);




                                ////rename local file
                                ////follow will error:
                                ////Windows Live Writer 遇到问题: The process cannot access the file because it is being used by another process
                                ////System.IO.File.Move(realSrcFullname, newSrcFullname);

                                //// try use copy instead rename

                                //// (1)replace title and alt
                                //string newTitleStr = "title=\"" + newFilenamePart + "\"";
                                //newSinglePicStr = newSinglePicStr.Replace(titleStr, newTitleStr);
                                //string newAltStr = "alt=\"" + newFilenamePart + "\"";
                                //newSinglePicStr = newSinglePicStr.Replace(altStr, newAltStr);

                                //// (2)generate 2 and 3 more pic
                                //System.IO.File.Copy(realSrcFullname, newSrcFullnameWithThumb);
                                //System.IO.File.Copy(realSrcFullname, newSrcFullnameNoThumb);
                                //string lastSufIdxFullname = "";
                                //int startNum = 1, endNum = 3;
                                //for (int i = startNum; i < (endNum + 1); i++)
                                //{
                                //    string sufIdxSrcFullname = hrefPath + newSrcFilenameNoThumb + "[" + i.ToString() + "]" + pointSuf;
                                //    System.IO.File.Copy(realSrcFullname, sufIdxSrcFullname);

                                //    lastSufIdxFullname = sufIdxSrcFullname;
                                //}

                                //// (3)replace the old filename with new filename

                                ////replace href
                                //newSinglePicStr = newSinglePicStr.Replace(hrefFullname, lastSufIdxFullname);
                                ////repplace src
                                //newSinglePicStr = newSinglePicStr.Replace(srcFullname, newSrcFullnameWithThumb);
                                ////newSinglePicStr = newSinglePicStr.Replace(srcFullname, newSrcFullnameNoThumb);
                            }
                        }
                    }



                    processedContent = processedContent.Replace(singlePicStr, newSinglePicStr);
                }
            }
        }

        private void btnTranslate_Click(object sender, EventArgs e)
        {
            translatePicName = true;

            ckbAutoScale.Checked = false;
            ckbReplaceHrefWithSr.Checked = false;
            ckbTargetBlank.Checked = false;

            commonProcessFunction();

            this.DialogResult = DialogResult.OK;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            translatePicName = false;

            commonProcessFunction();
            
            this.DialogResult = DialogResult.OK;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            string softUsage = "http://www.crifan.com/crifan_released_all/website/dotnet/picturemanager/";
            System.Diagnostics.Process.Start(softUsage);
        }

    }
}
