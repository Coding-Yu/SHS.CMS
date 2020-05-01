using AutoMapper;
using SHS.Application.Base;
using SHS.Domain.Core.Area;

namespace SHS.Application.AreaAppService.Dtos
{
    [AutoMap(typeof(Area))]
    public class AreaDto : BaseDto
    {

        /// <summary>
        /// 街道
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 国家/州
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string ZipCode { get; set; }

    }
}
