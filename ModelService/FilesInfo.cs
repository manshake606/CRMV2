using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModelService
{
    public class FilesInfo
    {
        private string _FileID;
        #region 文件ID
        /// <summary>
        /// 文件ID
        /// </summary>
        public string FileID
        {
            get
            {
                return _FileID;
            }
            set
            {
                _FileID = value;
            }
        }
        #endregion


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

        private DateTime _FileUploadDate;
        #region 文件上传日期
        /// <summary>
        /// 文件上传日期
        /// </summary>
        public DateTime FileUploadDate
        {
            get
            {
                return _FileUploadDate;
            }
            set
            {
                _FileUploadDate = value;
            }
        }
        #endregion

        private int _CustomerID;
        #region 用户ID
        /// <summary>
        /// 用户ID
        /// </summary>
        public int CustomerID
        {
            get
            {
                return _CustomerID;
            }
            set
            {
                _CustomerID = value;
            }
        }
        #endregion

        private int _FileType;
        #region 文件类型
        /// <summary>
        /// 文件类型
        /// </summary>
        public int FileType
        {
            get
            {
                return _FileType;
            }
            set
            {
                _FileType = value;
            }
        }
        #endregion

        private int _UploadedBy;
        #region 上传者
        /// <summary>
        /// 上传者
        /// </summary>
        public int UploadedBy
        {
            get
            {
                return _UploadedBy;
            }
            set
            {
                _UploadedBy = value;
            }
        }
        #endregion

        private int _Status;
        #region 文件状态
        /// <summary>
        /// 文件状态
        /// </summary>
        public int Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        #endregion

    }

}
