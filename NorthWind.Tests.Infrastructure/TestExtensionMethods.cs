using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace NorthWind.Tests.Infrastructure
{
    public static class TestExtensionMethods
    {
        public static Mock<IDbSet<T>> AsMockDbSet<T>(this IList<T> list) where T : class
        {
            var result = new Mock<IDbSet<T>>();
            var queryable = list.AsQueryable();

            result.Setup(r => r.Provider).Returns(queryable.Provider);
            result.Setup(r => r.Expression).Returns(queryable.Expression);
            result.Setup(r => r.ElementType).Returns(queryable.ElementType);
            result.Setup(r => r.GetEnumerator()).Returns(queryable.GetEnumerator);
            return result;
        }
    }
}
