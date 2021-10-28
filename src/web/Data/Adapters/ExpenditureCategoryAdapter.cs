using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using web.Data.Helpers;
using web.Data.ModelDtos;

namespace web.Data.Adapters
{
    public static class ExpenditureCategoryAdapter
    {
        public static List<ExpenditureCategoryDto> GetExpenditureCategorId(int categoryId, string userId)
        {
            var result = new List<ExpenditureCategoryDto>();

            var sql = string.Format(@"EXEC [sp_GetExpenditureID] {0}, {1}",
            DataBaseHelper.RawSafeSqlString(categoryId),
            DataBaseHelper.SafeSqlString(userId));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                foreach (DataRow item in sqlResult.Rows)
                {
                    result.Add(new ExpenditureCategoryDto
                    {
                        ExpenditureCategoryId = DataBaseHelper.GetIntegerValueFromRowByName(item, "ExpenditureCategoryId"),
                        Description = DataBaseHelper.GetValueFromRowByName(item, "Description"),
                        CategoryName = DataBaseHelper.GetValueFromRowByName(item, "CategoryName"),
                        CurrentSum = DataBaseHelper.GetDecimalValueFromRowByName(item, "CurrentSum"),
                        ExpenditureId = DataBaseHelper.GetIntegerValueFromRowByName(item, "ExpenditureId"),
                        IsShowUp = DataBaseHelper.GetBoolValueFromRowByName(item, "IsShowUp"),
                        CurrentDate = DataBaseHelper.GetDateTimeValueFromRowByName(item, "CurrentDate"),
                        DateOfPurchase = DataBaseHelper.GetDateTimeValueFromRowByName(item, "DateOfPurchase")
                    });
                }
            }                     

            return result;
        }

        public static List<ExpenditureCategoryDto> GetExpenditureCategoSowSum(int categoryId)
        {
            var result = new List<ExpenditureCategoryDto>();

            var sql = string.Format(@"EXEC [sp_GetCategoryShowSum] {0}",
            DataBaseHelper.RawSafeSqlString(categoryId));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                foreach (DataRow item in sqlResult.Rows)
                {
                    result.Add(new ExpenditureCategoryDto
                    {
                        CurrentAllSum = DataBaseHelper.GetDecimalValueFromRowByName(item, "CurrentAllSum")                       
                    });
                }
            }

            return result;
        }

        public static ExpenditureCategoryDto GetExpenditureCategoById(int Id)
        {
            ExpenditureCategoryDto result = new ExpenditureCategoryDto();

            var sql = string.Format(@"EXEC [sp_GetExpenditureCategoryDetailID] {0}",
               DataBaseHelper.RawSafeSqlString(Id));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                result = new ExpenditureCategoryDto
                {
                    ExpenditureCategoryId = DataBaseHelper.GetIntegerValueFromRowByName(sqlResult.Rows[0], "ExpenditureCategoryId"),                  
                    Description = DataBaseHelper.GetValueFromRowByName(sqlResult.Rows[0], "Description"),
                    CurrentDate = DataBaseHelper.GetDateTimeValueFromRowByName(sqlResult.Rows[0], "CurrentDate"),
                    IsShowUp = DataBaseHelper.GetBoolValueFromRowByName(sqlResult.Rows[0], "IsShowUp"),                
                    ExpenditureId = DataBaseHelper.GetIntegerValueFromRowByName(sqlResult.Rows[0], "ExpenditureId"),              
                    CurrentSum = DataBaseHelper.GetDecimalValueFromRowByName(sqlResult.Rows[0], "CurrentSum"),
                    DateOfPurchase = DataBaseHelper.GetDateTimeValueFromRowByName(sqlResult.Rows[0], "DateOfPurchase")
                };
            }

            return result;
        }

        public static int SaveExpenditureCategory(ExpenditureCategoryDto model)
        {
            var format = "yyyy-MM-dd HH:mm:ss:fff";
            var stringDate = model.DateOfPurchase.ToString(format);
            var sql = string.Empty;
            if (model.ExpenditureCategoryId > 0)
            {
                sql = string.Format(@"EXEC [sp_SaveExpenditureCategory] {0}, {1},{2},{3},{4},{5}",
                DataBaseHelper.RawSafeSqlString(model.ExpenditureCategoryId),
                DataBaseHelper.SafeSqlString(model.Description),
                DataBaseHelper.RawSafeSglDecimal((decimal)model.CurrentSum),
                DataBaseHelper.RawSafeSqlString(model.ExpenditureId),
                DataBaseHelper.SafeSqlString(model.IsShowUp),
                DataBaseHelper.SafeSqlString(stringDate));

                DataBaseHelper.RunSql(sql);
                return 0;
            }

            var ExpenditureCategoryId = 0;
            sql = string.Format(@"EXEC [sp_SaveExpenditureCategory] {0}, {1},{2},{3},{4},{5}",
            DataBaseHelper.RawSafeSqlString(model.ExpenditureCategoryId),
            DataBaseHelper.SafeSqlString(model.Description),
            DataBaseHelper.RawSafeSglDecimal((decimal)model.CurrentSum),
            DataBaseHelper.RawSafeSqlString(model.ExpenditureId),
            DataBaseHelper.SafeSqlString(model.IsShowUp),
            DataBaseHelper.SafeSqlString(stringDate));

            var dataResult = DataBaseHelper.GetSqlResult(sql);
            if (dataResult != null && dataResult.Rows.Count > 0)
            {
                foreach (DataRow row in dataResult.Rows)
                {
                    ExpenditureCategoryId = DataBaseHelper.GetIntegerValueFromRowByName(dataResult.Rows[0], "ExpenditureCategoryId");
                }
            }

            return ExpenditureCategoryId;
        }

        public static void DeleteExpenditureCategory(int id)
        {
            if (id > 0)
            {
                string sql = string.Format(@"exec sp_RemoveExpenditureCategory {0}",
                DataBaseHelper.RawSafeSqlString(id));
                DataBaseHelper.RunSql(sql);
            }
        }
    }
}
