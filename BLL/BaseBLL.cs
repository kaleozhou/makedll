using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BLL
{
    public partial class BaseBLL<T> where T : class,new()
    {
        protected DAL.BaseDAL<T> dal = new DAL.BaseDAL<T>();

        #region 添加新记录
        /// <summary>
        /// 添加新记录
        /// </summary>
        /// <param name="model">新的模型</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool Add(T model)
        {
            return dal.Add(model);
        } 
        #endregion
        //public  void FillField(ref T model)
        //{
        //    dal.FillFeild(ref model);
        //}
        #region 返回所有记录
        /// <summary>
        /// 返回所有记录
        /// </summary>
        /// <returns>返回IQueryable</returns>
        public IQueryable<T> GetAllList()
        {
            return dal.GetAllList();
        } 
        #endregion

        #region 返回执行Lambda 表达式的结果
        /// <summary>
        /// 返回执行Lambda 表达式的结果
        /// </summary>
        /// <param name="_whereLambda">Lambda表达式</param>
        /// <returns>返回IQueryable</returns>
        public IQueryable<T> GetListBy(Expression<Func<T, bool>> _whereLambda)
        {
            return dal.GetListBy(_whereLambda);
        } 
        #endregion

        #region 删除指定ID的记录   
        /// <summary>
        ///删除指定ID的记录
        /// </summary>
        /// <param name="_id">ID</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool DelByID(int _id)
        {
            return dal.DelByID(_id);
        } 
        #endregion

        #region 删除符合条件的记录
        /// <summary>
        ///删除符合条件的记录
        /// </summary>
        /// <param name="whereLambda">whereLambda</param>
        /// <returns>成功返回true,失败返回false</returns>
        public bool DelBy(Expression<Func<T, bool>> whereLambda)
        {
            if (dal.DelBy(whereLambda) > 0)
                return true;
            else
                return false;
        }
        #endregion

        #region 获取Lambda表达式的单条实体
        /// <summary>
        /// 获取Lambda表达式的单条实体
        /// </summary>
        /// <param name="whereLambda">Lambda表达式</param>
        /// <returns>返回单条实体</returns>
        public T GetSingleModelBy(Expression<Func<T, bool>> whereLambda)
        {
            return dal.GetListBy(whereLambda).FirstOrDefault();
        } 
        #endregion

        #region  获取指定ID的单条实体
        /// <summary>
        /// 获取指定ID的单条实体
        /// </summary>
        /// <param name="_id">ID</param>
        /// <returns>返回单条记录</returns>
        public T GetSingleModelByID(int _id)
        {

            return dal.GetModel(_id);
        } 
        #endregion

        #region 修改实体中指定的字段的值
        /// <summary>
        /// 修改实体中指定的字段的值
        /// </summary>
        /// <param name="model">要修改的实体</param>
        /// <param name="proNames">要修改的字段名</param>
        /// <returns>修改成功返回True,失败返回False</returns>
        public bool Modify(T model, params string[] proNames)
        {
            return dal.Modify(model, proNames) > 0 ? true : false;
        } 
        #endregion

        #region sql查询结果
        /// <summary>
        /// sql查询结果
        /// </summary>
        /// <param name="Sql">sql语名</param>
        /// <param name="para">sql参数</param>
        /// <returns></returns>
        public IEnumerable<T> QuerySql(string Sql, params object[] para)
        {
            return dal.QuerySql(Sql, para);
        } 
        #endregion

        #region 按条件获取指定条数的随机记录
        /// <summary>
        ///按条件获取指定条数的随机记录
        /// </summary>
        /// <param name="queryWhere">Lambda表达式</param>
        /// <param name="count">要获取的记录数</param>
        /// <returns></returns>
        public IQueryable<T> RandomList(Expression<Func<T, bool>> queryWhere, int count)
        {
            return dal.RandomList(queryWhere, count);
        } 
        #endregion

        #region 执行SQL语句
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="Sql">SQL语句</param>
        /// <returns>成功则返回True,失败则返回False</returns>
        public bool ExtSql(string Sql)
        {
            return dal.ExtSql(Sql);
        } 
        #endregion

        #region 获取指定属性值
        /// <summary>
        /// 获取指定属性值
        /// </summary>
        /// <param name="_name">字段名</param>
        /// <returns>返回object值</returns>
        public object GetValue(string _name)
        {
            return dal.GetValue(_name);
        } 
        #endregion
        public string JsonModel(Expression<Func<T, bool>> whereLambda)
        {
            return dal.JsonModel(whereLambda);
        }
        public string GetData(string Sql)
        {
           return  dal.GetData(Sql);
        }
         public DataRow GetRs(string Sql)
        {
            return dal.GetRs(Sql);
        }
        public  bool ExecNonSql(string Sql)
        {
            return dal.ExecNonSql(Sql);
        }
         public  DataSet Fill(string Sql)
        {
            return dal.Fill(Sql);
        }
    }
}
