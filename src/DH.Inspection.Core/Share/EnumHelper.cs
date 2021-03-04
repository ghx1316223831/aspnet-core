using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace DH.Inspection.Share
{
    public static class EnumHelper
    {
        /// <summary>
        /// 将枚举转为集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumEntity> EnumToList<T>()
        {
            List<EnumEntity> list = new List<EnumEntity>();

            foreach (var e in Enum.GetValues(typeof(T)))
            {
                EnumEntity m = new EnumEntity();
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    m.Desction = da.Description;
                }
                m.EnumValue = Convert.ToInt32(e);
                m.EnumName = e.ToString();
                list.Add(m);
            }
            return list;
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="EnumName"></param>
        /// <returns></returns>
        public static string GetEnumDesction(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])fi.GetCustomAttributes(
               typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : string.Empty;
        }

        /// <summary>
        /// 获取枚举描述
        /// </summary>
        /// <param name="enumValue">枚举选项</param>
        /// <returns></returns>
        public static string GetDescription(this Enum enumValue)
        {
            try
            {
                var field = enumValue.GetType().GetField(enumValue.ToString());
                var objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false); //获取描述属性
                return objs.Length == 0
                    ? enumValue.ToString()
                    : ((DescriptionAttribute)objs[0]).Description;
            }
            catch
            {
                return "";
            }
        }
    }
    /// <summary>
    /// 枚举实体
    /// </summary>
    public class EnumEntity
    {
        /// <summary>  
        /// 枚举的描述  
        /// </summary>  
        public string Desction { set; get; }

        /// <summary>  
        /// 枚举名称  
        /// </summary>  
        public string EnumName { set; get; }

        /// <summary>  
        /// 枚举对象的值  
        /// </summary>  
        public int EnumValue { set; get; }
    }
}
