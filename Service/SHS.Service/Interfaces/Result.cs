using System;
using System.Collections.Generic;
using System.Text;

namespace SHS.Service.Interfaces
{
    public class Result
    {

        public static readonly Result Successed = new Result(true, 0, null, null);
        public static readonly Result Failed = new Result(false, 0, null, null);
        public Result(bool status, int code, string message, long? entityId)
        {
            Status = status;
            Code = code;
            Message = message;
            EntityId = entityId;
        }
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; private set; }

        public long? EntityId { get; private set; }
        /// <summary>
        /// 调用信息
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// 返回码
        /// </summary>
        public int Code { get; private set; }

        public static Result Success()
        {
            return Successed;
        }

        public static Result Success(long entityId)
        {
            return new Result(true, 0, null, entityId);
        }

        public static Result Fail()
        {
            return Failed;
        }

        public static Result FromResult(bool result)
        {
            return result ? Successed : Failed;
        }

        public static Result Fail(int errCode, string message = null)
        {
            return new Result(false, errCode, message, null);
        }

        public static Result Exception(Exception ex)
        {
            return new Result(false, 500, ex.Message, null);
        }
    }
}
