using Core.Common.Data;
using System;
using System.Reflection;

namespace Core.EF.Utils
{
    public class Mapper<T, U> where T : Entity where U : class
    {
        public Mapper()
        {
            Type type = typeof(U);
            PropertyInfo[] properties = type.GetProperties();
            Prefix = properties[0].Name.Split('_')[0];
        }

        private string Prefix { get; }

        public T Map(U bdEntity)
        {
            return null;
        }

        public U Map(T entity)
        {
            return null;
        }
    }
}
