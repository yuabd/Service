using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Hammer.Core.Models
{
    public class Student
    {
        public int ID { get; set; }
        /// <summary>
        /// 准考证号
        /// </summary>
        public string StudentID { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Contact { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? BirthDate { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string IDCard { get; set; }
        /// <summary>
        /// 入学时间
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 毕业时间
        /// </summary>
        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public int Course { get; set; }
        /// <summary>
        /// 状态，0未通过，1通过未领取，2通过已领取
        /// </summary>
        public int State { get; set; }
        /// <summary>
        /// 证书号
        /// </summary>
        public string LisID { get; set; }

        [NotMapped]
        public string CourseName { get; set; }
    }
}
