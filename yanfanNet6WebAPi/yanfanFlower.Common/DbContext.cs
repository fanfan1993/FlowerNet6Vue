using SqlSugar;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace yanfanFlower.Common
{
    public class DbContext
    {

        public static SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = "Data Source=DESKTOP-5FSKN80;Initial Catalog=FlowerDb;Integrated Security=True;Encrypt=False",//连接符字串
            DbType = DbType.SqlServer, //数据库类型
            IsAutoCloseConnection = true //不设成true要手动close
        });
        public static void InitDatabase()
        {
            //如果不存在创建数据库
            db.DbMaintenance.CreateDatabase();
            //创建泰
            string nspace = "yanfanFlower.Model.Entitys";
            /// bin/Debug/net6.0 /
            Type[] ass = Assembly.LoadFrom("bin/Debug/net6.0/yanfanFlower.Model.dll").GetTypes().Where(p => p.Namespace == nspace).ToArray();
            db.CodeFirst.SetStringDefaultLength(200).InitTables(ass);
        }
    }
}
