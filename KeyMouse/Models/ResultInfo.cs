using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KeyMouse.Models
{
    public class ResultInfo : IResultInfo
    {
        public bool IsSucceed { get; set; }
        public string Message { get; set; }
        public int Value { get; set; }

        public ResultInfo()
        {
        }

        public ResultInfo(bool sSucceed)
            : this(sSucceed, null)
        {
        }

        public ResultInfo(bool isSucceed, string message)
        {
            this.IsSucceed = isSucceed;
            this.Message = message;
        }

        public ResultInfo(bool isSucceed, string message, int value)
        {
            this.IsSucceed = isSucceed;
            this.Message = message;
            this.Value = value;
        }
    }

    public class ResultInfo<T> : ResultInfo, IResultInfo<T>
    {
        public ResultInfo()
        {
        }

        public ResultInfo(bool isSucceed)
            : this(isSucceed, null)
        {
        }

        public ResultInfo(bool isSucceed, string message)
            : base(isSucceed, message)
        {
        }

        public ResultInfo(bool isSucceed, string message, int value)
            : base(isSucceed, message, value)
        {
        }

        public T Entity { get; set; }
    }


    public interface IResultInfo
    {
        bool IsSucceed { get; set; }
        string Message { get; set; }
    }

    public interface IResultInfo<T> : IResultInfo
    {
        T Entity { get; set; }
    }
}