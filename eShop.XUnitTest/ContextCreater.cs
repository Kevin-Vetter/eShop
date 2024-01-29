using DAL;
using DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;


namespace XUnitTest
{
    public class ContextCreater
    {
        public static eShopContext CreateContext([CallerMemberName] string dbname = "")
        {
            DbContextOptionsBuilder<eShopContext> builder = new DbContextOptionsBuilder<eShopContext>();
            builder.UseInMemoryDatabase(dbname);
                
            var context = new eShopContext(builder.Options);


            return context;

        }
    }
}
