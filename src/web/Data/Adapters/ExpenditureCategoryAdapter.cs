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
                        CurrentDate = DataBaseHelper.GetDateTimeValueFromRowByName(item, "CurrentDate")
                    });
                }
            }                     

            return result;
        }

        public static int SaveExpenditureCategory(ExpenditureCategoryDto model)
        {
            var sql = string.Empty;
            if (model.ExpenditureCategoryId > 0)
            {
                sql = string.Format(@"EXEC [sp_SaveExpenditureCategory] {0}, {1},{2},{3},{4}",
                DataBaseHelper.RawSafeSqlString(model.ExpenditureCategoryId),
                DataBaseHelper.SafeSqlString(model.Description),
                DataBaseHelper.RawSafeSglDecimal((decimal)model.CurrentSum),
                DataBaseHelper.RawSafeSqlString(model.ExpenditureId),
                DataBaseHelper.SafeSqlString(model.IsShowUp));

                DataBaseHelper.RunSql(sql);
                return 0;
            }

            var ExpenditureCategoryId = 0;
            sql = string.Format(@"EXEC [sp_SaveExpenditureCategory] {0}, {1},{2},{3},{4}",
            DataBaseHelper.RawSafeSqlString(model.ExpenditureCategoryId),
            DataBaseHelper.SafeSqlString(model.Description),
            DataBaseHelper.RawSafeSglDecimal((decimal)model.CurrentSum),
            DataBaseHelper.RawSafeSqlString(model.ExpenditureId),
            DataBaseHelper.SafeSqlString(model.IsShowUp));

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

    }
}
