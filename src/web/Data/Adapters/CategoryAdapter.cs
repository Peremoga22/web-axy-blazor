using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


using web.Data.Helpers;
using web.Data.ModelDtos;

namespace web.Data.Adapters
{
    public static class CategoryAdapter
    {
        public static List<CategoryDto> GetCategory(string userId)
        {
            var result = new List<CategoryDto>();

            string sql = null;
            sql = string.Format(@"exec [sp_GetCategory]  {0}",
            DataBaseHelper.SafeSqlString(userId));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);
          
            if (sqlResult.Rows.Count > 0)
            {
                foreach (DataRow item in sqlResult.Rows)
                {
                    result.Add(new CategoryDto
                    {
                        Id = DataBaseHelper.GetIntegerValueFromRowByName(item, "CategoryId"),
                        NameCategory = DataBaseHelper.GetValueFromRowByName(item, "CategoryName"),
                        DescriptionCategory = DataBaseHelper.GetValueFromRowByName(item, "Description"),
                        CurrentDate = DataBaseHelper.GetDateTimeValueFromRowByName(item, "CurentData"),
                        IsIncome = DataBaseHelper.GetBoolValueFromRowByName(item, "IsIncome"),
                        ReceiptId = DataBaseHelper.GetIntegerValueFromRowByName(item, "ReceiptId"),
                        NameReceipt = DataBaseHelper.GetValueFromRowByName(item, "NameReceipt"),
                        SumReceipt = DataBaseHelper.GetDecimalValueFromRowByName(item, "SumReceipt"),
                        ExpenditureId = DataBaseHelper.GetIntegerValueFromRowByName(item, "ExpenditureId"),
                        NameExpenditure = DataBaseHelper.GetValueFromRowByName(item, "NameExpenditure"),
                        SumExpenditure = DataBaseHelper.GetDecimalValueFromRowByName(item, "SumExpenditure"),
                        IsCheckForDelete = DataBaseHelper.GetBoolValueFromRowByName(item, "IsCheckForDelete")
                    });
                }
            }

            return result;
        }


        public static List<CategoryDto> GetCategoryList(CategoryDto model)
        {
            var result = new List<CategoryDto>();

            var startDate = "yyyy-MM-dd HH:mm:ss:fff";
            var startDateString = model.StartDate.ToString(startDate);
            var endDate = "yyyy-MM-dd HH:mm:ss:fff";
            var endDateString = model.EndDate.ToString(endDate);
            string sql = null;

            sql = string.Format(@"exec [sp_GetCategoryFilter] {0}, {1},{2},{3},{4}",
            DataBaseHelper.SafeSqlString(startDateString),
            DataBaseHelper.SafeSqlString(endDateString),
            DataBaseHelper.SafeSqlString(model.IsIncome),
            DataBaseHelper.SafeSqlString(model.UserId),
            DataBaseHelper.SafeSqlString(model.Filter));          
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                foreach (DataRow item in sqlResult.Rows)
                {
                    result.Add(new CategoryDto
                    {
                        Id = DataBaseHelper.GetIntegerValueFromRowByName(item, "CategoryId"),
                        NameCategory = DataBaseHelper.GetValueFromRowByName(item, "CategoryName"),
                        DescriptionCategory = DataBaseHelper.GetValueFromRowByName(item, "Description"),
                        CurrentDate = DataBaseHelper.GetDateTimeValueFromRowByName(item, "CurentData"),
                        IsIncome = DataBaseHelper.GetBoolValueFromRowByName(item, "IsIncome"),
                        ReceiptId = DataBaseHelper.GetIntegerValueFromRowByName(item, "ReceiptId"),
                        NameReceipt = DataBaseHelper.GetValueFromRowByName(item, "NameReceipt"),
                        SumReceipt = DataBaseHelper.GetDecimalValueFromRowByName(item, "SumReceipt"),
                        ExpenditureId = DataBaseHelper.GetIntegerValueFromRowByName(item, "ExpenditureId"),
                        NameExpenditure = DataBaseHelper.GetValueFromRowByName(item, "NameExpenditure"),
                        SumExpenditure = DataBaseHelper.GetDecimalValueFromRowByName(item, "SumExpenditure")

                    });
                }
            }

            return result;
        }

        public static void SaveCategory(CategoryDto model)
        {
            if (model.Id > 0)
            {
                if (model.ReceiptId == 0)
                {
                    model.ReceiptId = null;
                }

                if (model.ExpenditureId == 0)
                {
                    model.ExpenditureId = null;
                }

                var format = "yyyy-MM-dd HH:mm:ss:fff";
                var stringDate = model.CurrentDate.ToString(format);

                var sql = string.Format(@"EXEC [sp_SaveCategory] {0}, {1}, {2}, {3},{4},{5},{6},{7},{8}",
                DataBaseHelper.RawSafeSqlString(model.Id),
                DataBaseHelper.SafeSqlString(model.NameCategory),
                DataBaseHelper.SafeSqlString(model.DescriptionCategory),
                DataBaseHelper.SafeSqlString(stringDate),
                DataBaseHelper.SafeSqlString(model.IsIncome),
                DataBaseHelper.RawSafeSqlString(model.ExpenditureId),
                DataBaseHelper.RawSafeSqlString(model.ReceiptId),
                DataBaseHelper.SafeSqlString(model.UserId),
                DataBaseHelper.SafeSqlString(model.IsCheckForDelete));

                var dataResult = DataBaseHelper.RunSql(sql);
            }
            else
            {
                if (model.ReceiptId == 0)
                {
                    model.ReceiptId = null;
                }

                if (model.ExpenditureId == 0)
                {
                    model.ExpenditureId = null;
                }

                var format = "yyyy-MM-dd HH:mm:ss:fff";
                var stringDate = model.CurrentDate.ToString(format);

                var sql = string.Format(@"EXEC [sp_SaveCategory] {0}, {1}, {2}, {3},{4},{5},{6},{7},{8}",
                DataBaseHelper.RawSafeSqlString(model.Id),
                DataBaseHelper.SafeSqlString(model.NameCategory),
                DataBaseHelper.SafeSqlString(model.DescriptionCategory),
                DataBaseHelper.SafeSqlString(stringDate),
                DataBaseHelper.SafeSqlString(model.IsIncome),
                DataBaseHelper.RawSafeSqlString(model.ExpenditureId),
                DataBaseHelper.RawSafeSqlString(model.ReceiptId),
                DataBaseHelper.SafeSqlString(model.UserId),
                DataBaseHelper.SafeSqlString(model.IsCheckForDelete));

                var dataResult = DataBaseHelper.RunSql(sql);
            }


        }

        public static CategoryDto GetCategoryDtoId(int Id)
        {
            CategoryDto result = new CategoryDto();

            var sql = string.Format(@"EXEC [sp_GetCategoryDetailID] {0}",
               DataBaseHelper.RawSafeSqlString(Id));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                result = new CategoryDto
                {
                    Id = DataBaseHelper.GetIntegerValueFromRowByName(sqlResult.Rows[0], "CategoryId"),
                    NameCategory = DataBaseHelper.GetValueFromRowByName(sqlResult.Rows[0], "CategoryName"),
                    DescriptionCategory = DataBaseHelper.GetValueFromRowByName(sqlResult.Rows[0], "Description"),
                    CurrentDate = DataBaseHelper.GetDateTimeValueFromRowByName(sqlResult.Rows[0], "CurentData"),
                    IsIncome = DataBaseHelper.GetBoolValueFromRowByName(sqlResult.Rows[0], "IsIncome"),
                    ReceiptId = DataBaseHelper.GetIntegerValueFromRowByName(sqlResult.Rows[0], "ReceiptId"),
                    NameReceipt = DataBaseHelper.GetValueFromRowByName(sqlResult.Rows[0], "NameReceipt"),
                    SumReceipt = DataBaseHelper.GetDecimalValueFromRowByName(sqlResult.Rows[0], "SumReceipt"),
                    ExpenditureId = DataBaseHelper.GetIntegerValueFromRowByName(sqlResult.Rows[0], "ExpenditureId"),
                    NameExpenditure = DataBaseHelper.GetValueFromRowByName(sqlResult.Rows[0], "NameExpenditure"),
                    SumExpenditure = DataBaseHelper.GetDecimalValueFromRowByName(sqlResult.Rows[0], "SumExpenditure"),
                };
            }

            return result;
        }

        public static void Delete(int id)
        {
            if (id > 0)
            {
                string sql = string.Format(@"exec sp_RemoveCategory {0}",
                DataBaseHelper.RawSafeSqlString(id));
                DataBaseHelper.RunSql(sql);
            }
        }

        public static IEnumerable<CategoryDto> GetCategorySum(string userId)
        {
            var result = new List<CategoryDto>();
            var  isShow = true;
            string sql = null;
            sql = string.Format(@"exec [sp_GetCategorySum] {0},{1}",
            DataBaseHelper.SafeSqlString(isShow),
            DataBaseHelper.SafeSqlString(userId));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                foreach (DataRow item in sqlResult.Rows)
                {
                    result.Add(new CategoryDto
                    {
                        Id = DataBaseHelper.GetIntegerValueFromRowByName(item, "CategoryId"),
                        NameCategory = DataBaseHelper.GetValueFromRowByName(item, "CategoryName"),
                        DescriptionCategory = DataBaseHelper.GetValueFromRowByName(item, "Description"),
                        CurrentDate = DataBaseHelper.GetDateTimeValueFromRowByName(item, "CurentData"),
                        SumReceipt = DataBaseHelper.GetDecimalValueFromRowByName(item, "SumReceipt"),
                        SumExpenditure = DataBaseHelper.GetDecimalValueFromRowByName(item, "SumExpenditure"),
                        BalansRecipt = DataBaseHelper.GetDecimalValueFromRowByName(item, "BalansRecipt"),
                        BalansExpenditure = DataBaseHelper.GetDecimalValueFromRowByName(item, "BalansExpenditure"),
                        UserId = DataBaseHelper.GetValueFromRowByName(item, "UserId")
                    });
                }
            }

            return result;
        }
    }
}
