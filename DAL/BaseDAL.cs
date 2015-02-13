using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
namespace DAL
{
    public partial class BaseDAL<T> where T : class,new()
    {
        MODEL.BlueVacationEntities DB = new MODEL.BlueVacationEntities();
       
        SqlConnection Conn = null;
        #region 1.0 新增 实体 +int Add(T model)

        /// <summary>
        /// 新增 实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add(T model)
        {
            //try
            //{
                
                FillFeild(ref model);
                DB.Set<T>().Add(model);
                if (DB.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            //}
            //catch
            //{
            //    return false;
            //}
        }
        #endregion
        

        #region 2.0 根据 id 删除
        /// <summary>
        /// 根据 id 删除
        /// </summary>
        /// <param name="model">包含要删除id的对象</param>
        /// <returns></returns>
        public bool DelByID(int id)
        {
            //try
            //{
                using (var content = new MODEL.BlueVacationEntities())
                {
                    Type t = typeof(T); // model.GetType();
                    //获取 实体类 类型对象
                    //获取 实体类 所有的 公有属性
                    if (content.Database.ExecuteSqlCommand("delete from " + t.Name + " where ID =" + id) > 0)
                        return true;
                    else
                        return false;
                }
            //}
            //catch
            //{
            //    return false;
            //}

        }
        #endregion
        ///// <summary>
        ///// 删除指定记录到回收站
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public bool DelToRecycleByID(int id)
        //{
        //    try
        //    {
        //        using (var content = new MODEL.JinCmsEntities())
        //        {
        //            Type t = typeof(T); // model.GetType();
        //            //获取 实体类 类型对象
        //            //获取 实体类 所有的 公有属性
        //            if (content.Database.ExecuteSqlCommand("update" + t.Name + " set IsDel=true where ID =" + id) > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}

        #region 3.0 根据条件删除 +int DelBy(Expression<Func<T, bool>> delWhere)
        /// <summary>
        /// 3.0 根据条件删除
        /// </summary>
        /// <param name="delWhere"></param>
        /// <returns></returns>
        public int DelBy(Expression<Func<T, bool>> delWhere)
        {

            //3.1查询要删除的数据
            List<T> listDeleting = DB.Set<T>().Where(delWhere).ToList();
            //3.2将要删除的数据 用删除方法添加到 EF 容器中
            listDeleting.ForEach(u =>
            {
                DB.Set<T>().Attach(u);//先附加到 EF容器
                DB.Set<T>().Remove(u);//标识为 删除 状态
            });
            //3.3一次性 生成sql语句到数据库执行删除
            return DB.SaveChanges();
        }
        #endregion

        #region 4.0 修改 +int Modify(T model, params string[] proNames)
        /// <summary>
        /// 4.0 修改，如：
        /// T u = new T() { uId = 1, uLoginName = "asdfasdf" };
        /// this.Modify(u, "uLoginName");
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        public int Modify(T model, params string[] proNames)
        {
            //try
            //{
                DB = new MODEL.BlueVacationEntities();
                //4.1将 对象 添加到 EF中
                FillFeild(ref model);
                DbEntityEntry entry = DB.Entry<T>(model);
                //4.2先设置 对象的包装 状态为 Unchanged

                //var entry = DbContext.Set<T>().Find(0);
                //if (entry != null)
                //{
                //    DbContext.Entry<T>(entry).State = System.Data.EntityState.Detached; //这个是在同一个上下文能修改的关键
                //}
                entry.State = System.Data.EntityState.Unchanged;
                Type t = typeof(T); // model.GetType();
                //获取 实体类 所有的 公有属性
                List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
                //4.3循环 被修改的属性名 数组
                List<string> FeildList = new List<string>();
                proInfos.ForEach(p =>
                {
                    FeildList.Add(p.Name);
                });
                foreach (string proName in proNames)
                {
                    //4.4将每个 被修改的属性的状态 设置为已修改状态;后面生成update语句时，就只为已修改的属性 更新
                    if (FeildList.Contains(proName))
                        entry.Property(proName).IsModified = true;
                }
                //4.4一次性 生成sql语句到数据库执行
                return DB.SaveChanges();
            //}
            //catch (DbEntityValidationException dbEx)
            //{

            //    return 0;
            //}

        }
        #endregion

        #region 4.0 批量修改 +int Modify(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        /// <summary>
        /// 4.0 批量修改
        /// </summary>
        /// <param name="model">要修改的实体对象</param>
        /// <param name="whereLambda">查询条件</param>
        /// <param name="proNames">要修改的 属性 名称</param>
        /// <returns></returns>
        public int ModifyBy(T model, Expression<Func<T, bool>> whereLambda, params string[] modifiedProNames)
        {
            //4.1查询要修改的数据
            List<T> listModifing = DB.Set<T>().AsNoTracking().Where(whereLambda).ToList();

            //获取 实体类 类型对象
            Type t = typeof(T); // model.GetType();
            //获取 实体类 所有的 公有属性
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            //创建 实体属性 字典集合
            Dictionary<string, PropertyInfo> dictPros = new Dictionary<string, PropertyInfo>();
            //将 实体属性 中要修改的属性名 添加到 字典集合中 键：属性名  值：属性对象
            proInfos.ForEach(p =>
            {
                if (modifiedProNames.Contains(p.Name))
                {
                    dictPros.Add(p.Name, p);
                }
            });

            //4.3循环 要修改的属性名
            foreach (string proName in modifiedProNames)
            {
                //判断 要修改的属性名是否在 实体类的属性集合中存在
                if (dictPros.ContainsKey(proName))
                {
                    //如果存在，则取出要修改的 属性对象
                    PropertyInfo proInfo = dictPros[proName];
                    //取出 要修改的值
                    object newValue = proInfo.GetValue(model, null); //object newValue = model.uName;

                    //4.4批量设置 要修改 对象的 属性
                    foreach (T usrO in listModifing)
                    {
                        //为 要修改的对象 的 要修改的属性 设置新的值
                        proInfo.SetValue(usrO, newValue, null); //usrO.uName = newValue;
                    }
                }
            }
            //4.4一次性 生成sql语句到数据库执行
            return DB.SaveChanges();
        }
        #endregion

        #region 修改指定的模型
        public void GetNewModelTrans(ref T model, string[] modifiedProNames, string[] modifiedProValue)
        {
            Type t = typeof(T);
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            Dictionary<string, PropertyInfo> dictPros = new Dictionary<string, PropertyInfo>();
            proInfos.ForEach(p =>
            {
                if (modifiedProNames.Contains(p.Name))
                {
                    dictPros.Add(p.Name, p);
                }
            });
            for (int i = 0; i < modifiedProNames.Length; i++)
            {
                string proName = modifiedProNames[i];
                if (dictPros.ContainsKey(proName))
                {
                    //如果存在，则取出要修改的 属性对象
                    PropertyInfo proInfo = dictPros[proName];
                    //取出 要修改的值
                    object newValue = modifiedProValue[i]; //object newValue = model.uName;
                    proInfo.SetValue(model, newValue, null); //usrO.uName = newValue;

                }
            }

        }
        #endregion

        #region 设定指定字段的默认值
        /// <summary>
        /// 设定指定字段的默认值
        /// </summary>
        /// <param name="model"></param>
        /// <param name="modifiedProNames"></param>
        public void FillFeild(ref T model)
        {
            Type t = typeof(T);
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            Dictionary<string, PropertyInfo> dictPros = new Dictionary<string, PropertyInfo>();
            Dictionary<string, string> FeildList = GetDefaultFeild();
            proInfos.ForEach(p =>
            {
                dictPros.Add(p.Name, p);
            });

            foreach (var item in FeildList)
            {
                string proName = item.Key;
                if (dictPros.ContainsKey(proName))
                {
                    //如果存在，则取出要修改的 属性对象
                    PropertyInfo proInfo = dictPros[proName];
                    if (proInfo.GetValue(model, null) == null)
                    {
                        if (proInfo.PropertyType.FullName.Contains("DateTime"))
                        {
                            proInfo.SetValue(model, DateTime.Now, null);
                        }
                        if (proInfo.PropertyType.FullName.Contains("String"))
                        {
                            if (item.Value == "''" || string.IsNullOrEmpty(item.Value))
                            {
                                proInfo.SetValue(model, "", null);
                            }
                            else
                            {
                                proInfo.SetValue(model, item.Value, null);
                            }
                        }
                        if (proInfo.PropertyType.FullName.Contains("Int32"))
                        {
                            if (string.IsNullOrEmpty(item.Value))
                                proInfo.SetValue(model, 0, null);
                            else
                                proInfo.SetValue(model, int.Parse(item.Value), null);

                        }
                    }

                }
            }

        }
        #endregion

        #region 获取要修改的字段
        public Dictionary<string, string> GetDefaultFeild()
        {
            Type t = typeof(T);
            DataSet ds = Fill("exec sp_helpconstraint " + t.Name);
            DataTable dt = ds.Tables[1];
            List<string> KEY = new List<string>();
            Dictionary<string, string> result = new Dictionary<string, string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                //try
                //{

                    DataRow row = dt.Rows[i];
                    if (!string.IsNullOrEmpty(row["constraint_type"].ToString()) && row["constraint_type"].ToString() != " ")
                    {
                        string Feild = row["constraint_type"].ToString().Replace("DEFAULT on column ", "");
                        if (Feild.Contains("FOREIGN KEY") || Feild.Contains("PRIMARY KEY"))
                        {
                            KEY.Add(row["constraint_keys"].ToString());
                        }
                        else
                        {
                            string value = row["constraint_keys"].ToString();
                            value = value.Replace("(", "").Replace(")", "");
                            result.Add(Feild, value);
                        }
                    }
                //}
                //catch (System.Exception)
                //{


                //}

            }
            DataSet dsFeild = Fill("Select name from syscolumns Where ID=OBJECT_ID('" + t.Name + "') ");
            DataTable dtFeild = dsFeild.Tables[0];
            for (int i = 0; i < dtFeild.Rows.Count; i++)
            {
                string value = dtFeild.Rows[i]["name"].ToString();
                if (!result.ContainsKey(value) && !KEY.Contains(value))
                {
                    result.Add(value, "");
                }
            }
            return result;
        }
        #endregion

        #region 5.0 根据条件查询 +List<T> GetListBy(Expression<Func<T,bool>> whereLambda)
        /// <summary>
        /// 5.0 根据条件查询 +List<T> GetListBy(Expression<Func<T,bool>> whereLambda)
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetListBy(Expression<Func<T, bool>> whereLambda)
        {
            IQueryable<T> Result = DB.Set<T>().AsNoTracking().Where(whereLambda);
            return Result;
        }
        #endregion

        #region 返回所有记录
        /// <summary>
        /// 返回所有记录
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public IQueryable<T> GetAllList()
        {
            return DB.Set<T>().AsNoTracking();

        }
        #endregion

        #region 5.1 根据条件 排序 和查询 + List<T> GetListBy<TKey>
        /// <summary>
        /// 5.1 根据条件 排序 和查询
        /// </summary>
        /// <typeparam name="TKey">排序字段类型</typeparam>
        /// <param name="whereLambda">查询条件 lambda表达式</param>
        /// <param name="orderLambda">排序条件 lambda表达式</param>
        /// <returns></returns>
        public IQueryable<T> GetListBy<TKey>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderLambda)
        {
            return DB.Set<T>().AsNoTracking().Where(whereLambda).OrderBy(orderLambda);
        }
        #endregion

        #region 6.0 分页查询 + List<T> GetPagedList<TKey>
        /// <summary>
        /// 6.0 分页查询 + List<T> GetPagedList<TKey>
        /// </summary>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="whereLambda">条件 lambda表达式</param>
        /// <param name="orderBy">排序 lambda表达式</param>
        /// <returns></returns>
        public IQueryable<T> GetPagedList<TKey>(int pageIndex, int pageSize, Expression<Func<T, bool>> whereLambda, Expression<Func<T, TKey>> orderBy, ref int total)
        {
            // 分页 一定注意： Skip 之前一定要 OrderBy
            IQueryable<T> result = DB.Set<T>().AsNoTracking().Where(whereLambda).OrderBy(orderBy);
            total = result.Count();
            return result.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
        #endregion

        #region 保存字体
        public bool Save(T model)
        {
            //try
            //{
                DB.Configuration.ValidateOnSaveEnabled = false;
                DB.SaveChanges();
                DB.Configuration.ValidateOnSaveEnabled = true;
                return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }
        #endregion

        #region 实体部分更新
        /// <summary>
        /// 实体部分更新
        /// </summary>
        /// <param name="originalEmployee">需修改的实体</param>
        /// <param name="newEmployee">新的实体</param>
        public void Modify(T _OldModel, T _NewModel)
        {
            DB.Entry(_OldModel).CurrentValues.SetValues(_NewModel);
            DB.SaveChanges();
        }
        #endregion

        #region 通过ID获取实体
        public T GetModel(int id)
        {
            T model = new T();
            Type t = typeof(T); // model.GetType();
            //获取 实体类 类型对象
            //获取 实体类 所有的 公有属性
            List<PropertyInfo> proInfos = t.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            //创建 实体属性 字典集合
            Dictionary<string, PropertyInfo> dictPros = new Dictionary<string, PropertyInfo>();
            //将 实体属性 中要修改的属性名 添加到 字典集合中 键：属性名  值：属性对象

            proInfos.ForEach(p => dictPros.Add(p.Name, p));
            PropertyInfo proInfo = dictPros["ID"];
            //取出 要修改的值
            proInfo.SetValue(model, id, null); //object newValue = model.uName;
            DB.Set<T>().Attach(model);
            return model;
        }
        #endregion

        public string JsonModel(Expression<Func<T, bool>> whereLambda)
        {
            MODEL.BlueVacationEntities QueryDB = new MODEL.BlueVacationEntities();
            QueryDB.Configuration.ProxyCreationEnabled = false;
            T model = QueryDB.Set<T>().AsNoTracking().Where(whereLambda).FirstOrDefault();
            return JsonConvert.SerializeObject(model);
        }
        public bool ExtSql(string Sql)
        {
            using (var content = new MODEL.BlueVacationEntities())
            {
                if (content.Database.ExecuteSqlCommand(Sql) > 0)
                    return true;
                else
                    return false;

            }
        }
        public IEnumerable<T> QuerySql(string Sql, params object[] para)
        {

            return DB.Database.SqlQuery<T>(Sql, para);
        }
        public IQueryable<T> RandomList(Expression<Func<T, bool>> queryWhere, int count)
        {
            return DB.Set<T>().AsNoTracking().Where(queryWhere).OrderBy(s => Guid.NewGuid()).Take(count);
        }
        public object GetValue(string propertyName)
        {
            return this.GetType().GetProperty(propertyName).GetValue(this, null);
        }

        public string GetData(string Sql)
        {
            //try
            //{
                DataSet Ds = Fill(Sql);
                DataTable MyDt = Ds.Tables[0];
                if (MyDt.Rows.Count > 0)
                    return MyDt.Rows[0][0].ToString();
                else
                    return "";
            //}
            //catch
            //{
            //    return "";
            //}
        }
        public DataRow GetRs(string Sql)
        {

            DataRow Rs = null;
            //try
            //{
                DataSet Ds = Fill(Sql);
                DataTable MyDt = Ds.Tables[0];
                if (MyDt.Rows.Count > 0)
                    Rs = MyDt.Rows[0];
            //}
            //catch
            //{ }
            return Rs;
        }

        public bool ExecNonSql(string Sql)
        {
            //try
            //{
                Conn = (SqlConnection)DB.Database.Connection;
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                SqlCommand MyCommand = new SqlCommand(Sql, Conn);
                MyCommand.ExecuteNonQuery();
                MyCommand = null;
                return true;
            //}
            //catch
            //{ return false; }

        }
        public DataSet Fill(string Sql)
        {
            DataSet Ds = new DataSet();
            //try
            //{
                Conn = (SqlConnection)DB.Database.Connection;
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
                SqlDataAdapter MyDataAdAapter = new SqlDataAdapter(Sql, Conn);
                MyDataAdAapter.TableMappings.Add("Table", "MyTable");
                SqlCommandBuilder Scb = new SqlCommandBuilder(MyDataAdAapter);
                MyDataAdAapter.Fill(Ds);
                int count = Ds.Tables[0].Rows.Count;
                return Ds;
            //}
            //catch
            //{
            //    return Ds;
            //}

        }
    }
}

