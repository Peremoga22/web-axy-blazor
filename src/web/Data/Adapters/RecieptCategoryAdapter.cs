using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using web.Data.Helpers;
using web.Data.ModelDtos;

namespace web.Data.Adapters
{
    public class RecieptCategoryAdapter
    {
        public static List<RecieptCategoryDto> GetRecieptCategorId(int categoryId, string userId)
        {
            var result = new List<RecieptCategoryDto>();

            var sql = string.Format(@"EXEC [sp_GetRecieptCategoryID] {0}, {1}",
            DataBaseHelper.RawSafeSqlString(categoryId),
            DataBaseHelper.SafeSqlString(userId));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                foreach (DataRow item in sqlResult.Rows)
                {
                    result.Add(new RecieptCategoryDto
                    {
                        RecieptCategoryId = DataBaseHelper.GetIntegerValueFromRowByName(item, "ReceiptCategoryId"),
                        Description = DataBaseHelper.GetValueFromRowByName(item, "Description"),
                        CategoryName = DataBaseHelper.GetValueFromRowByName(item, "CategoryName"),
                        CurrentSum = DataBaseHelper.GetDecimalValueFromRowByName(item, "CurrentSum"),
                        RecieptId = DataBaseHelper.GetIntegerValueFromRowByName(item, "ReceiptId"),
                        IsShowUp = DataBaseHelper.GetBoolValueFromRowByName(item, "IsShowUp"),
                        CurrentDate = DataBaseHelper.GetDateTimeValueFromRowByName(item, "CurrentDate"),
                        DateOfIncome = DataBaseHelper.GetDateTimeValueFromRowByName(item, "DateOfIncome")
                    });
                }
            }

            return result;
        }

        public static List<RecieptCategoryDto> GetRecieptCategoSowSum(int categoryId)
        {
            var result = new List<RecieptCategoryDto>();

            var sql = string.Format(@"EXEC [sp_GetRecieptCategoryShowSum] {0}",
            DataBaseHelper.RawSafeSqlString(categoryId));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                foreach (DataRow item in sqlResult.Rows)
                {
                    result.Add(new RecieptCategoryDto
                    {
                        CurrentAllSum = DataBaseHelper.GetDecimalValueFromRowByName(item, "CurrentAllSum")
                    });
                }
            }

            return result;
        }


        public static RecieptCategoryDto GetRecieptCategoById(int Id)
        {
            RecieptCategoryDto result = new RecieptCategoryDto();

            var sql = string.Format(@"EXEC [sp_GetRecieptCategoryDetailID] {0}",
               DataBaseHelper.RawSafeSqlString(Id));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                result = new RecieptCategoryDto
                {
                    RecieptCategoryId = DataBaseHelper.GetIntegerValueFromRowByName(sqlResult.Rows[0], "ReceiptCategoryId"),
                    Description = DataBaseHelper.GetValueFromRowByName(sqlResult.Rows[0], "Description"),
                    CurrentDate = DataBaseHelper.GetDateTimeValueFromRowByName(sqlResult.Rows[0], "CurrentDate"),
                    IsShowUp = DataBaseHelper.GetBoolValueFromRowByName(sqlResult.Rows[0], "IsShowUp"),
                    RecieptId = DataBaseHelper.GetIntegerValueFromRowByName(sqlResult.Rows[0], "ReceiptId"),
                    CurrentSum = DataBaseHelper.GetDecimalValueFromRowByName(sqlResult.Rows[0], "CurrentSum"),
                    DateOfIncome = DataBaseHelper.GetDateTimeValueFromRowByName(sqlResult.Rows[0], "DateOfIncome")
                };
            }

            return result;
        }

        public static int SaveRecieptCategory(RecieptCategoryDto model)
        {
            var format = "yyyy-MM-dd HH:mm:ss:fff";
            var stringDate = model.DateOfIncome.ToString(format);
            var sql = string.Empty;
            if (model.RecieptCategoryId > 0)
            {
                sql = string.Format(@"EXEC [sp_SaveRecieptCategory] {0}, {1},{2},{3},{4},{5}",
                DataBaseHelper.RawSafeSqlString(model.RecieptCategoryId),
                DataBaseHelper.SafeSqlString(model.Description),
                DataBaseHelper.RawSafeSglDecimal((decimal)model.CurrentSum),
                DataBaseHelper.RawSafeSqlString(model.RecieptId),
                DataBaseHelper.SafeSqlString(model.IsShowUp),
                DataBaseHelper.SafeSqlString(stringDate));

                DataBaseHelper.RunSql(sql);
                return 0;
            }

            var RecieptCategoryId = 0;
            sql = string.Format(@"EXEC [sp_SaveRecieptCategory] {0}, {1},{2},{3},{4},{5}",
            DataBaseHelper.RawSafeSqlString(model.RecieptCategoryId),
            DataBaseHelper.SafeSqlString(model.Description),
            DataBaseHelper.RawSafeSglDecimal((decimal)model.CurrentSum),
            DataBaseHelper.RawSafeSqlString(model.RecieptId),
            DataBaseHelper.SafeSqlString(model.IsShowUp),
            DataBaseHelper.SafeSqlString(stringDate));

            var dataResult = DataBaseHelper.GetSqlResult(sql);
            if (dataResult != null && dataResult.Rows.Count > 0)
            {
                foreach (DataRow row in dataResult.Rows)
                {
                    RecieptCategoryId = DataBaseHelper.GetIntegerValueFromRowByName(dataResult.Rows[0], "RecieptCategoryId");
                }
            }

            return RecieptCategoryId;
        }

        public static void DeleteRecieptCategory(int id)
        {
            if (id > 0)
            {
                string sql = string.Format(@"exec sp_RemoveReceiptCategory {0}",
                DataBaseHelper.RawSafeSqlString(id));
                DataBaseHelper.RunSql(sql);
            }
        }
    }
}
