using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
   public class FilesInfo
    {
        private string _FileName;
        #region 文件名
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                _FileName = value;
            }
        }
        #endregion

        private string _FolderID;
        #region 文件夹ID
        /// <summary>
        /// 文件夹ID
        /// </summary>
        public string FolderID
        {
            get
            {
                return _FolderID;
            }
            set
            {
                _FolderID = value;
            }
        }
        #endregion
    }
}
