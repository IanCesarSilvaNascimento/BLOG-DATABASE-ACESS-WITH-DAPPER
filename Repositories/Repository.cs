using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories{

    public class Repository<T> where T : class{
        private SqlConnection? connection;

        public Repository(SqlConnection? connection)
              => this.connection = connection;
        

        public IEnumerable<T> Get()
            => Database.connection.GetAll<T>();

     
        public void Create(T model)
           => Database.connection.Insert<T>(model);
        
        public void Update(T model)            
            => Database.connection.Update<T>(model);
        

      
         public void Delete(int id){                
            var model = Database.connection.Get<T>(id);
            Database.connection.Delete<T>(model);
        }
        
    }
}