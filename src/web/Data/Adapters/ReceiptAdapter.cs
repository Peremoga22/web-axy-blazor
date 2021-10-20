﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using web.Data.Helpers;
using web.Data.ModelDtos;

namespace web.Data.Adapters
{
    public static class ReceiptAdapter
    {
        public static IEnumerable<ReceiptDto> GetReceipt()
        {
            var result = new List<ReceiptDto>();

            string sql = null;
            sql = string.Format(@"exec [sp_GetReceipt]");
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                foreach (DataRow item in sqlResult.Rows)
                {
                    result.Add(new ReceiptDto
                    {
                        Id = DataBaseHelper.GetIntegerValueFromRowByName(item, "ReceiptId"),
                        Name = DataBaseHelper.GetValueFromRowByName(item, "Name"),
                        Sum = DataBaseHelper.GetDecimalValueFromRowByName(item, "Sum")
                    });
                }
            }

            return result;
        }

        public static int SaveReceipt(ReceiptDto model)
        {
            var sql = string.Empty;
            var ReceiptId = 0;
            if (model.Id > 0)
            {
                sql = string.Format(@"EXEC [sp_SaveReceipt] {0}, {1},{2}",
                DataBaseHelper.RawSafeSqlString(model.Id),
                DataBaseHelper.SafeSqlString(model.Name),
                DataBaseHelper.RawSafeSglDecimal((decimal)model.Sum));
                var sqlResult = DataBaseHelper.RunSql(sql);
                return 0;
            }

            sql = string.Format(@"EXEC [sp_SaveReceipt] {0}, {1},{2}",
            DataBaseHelper.RawSafeSqlString(model.Id),
            DataBaseHelper.SafeSqlString(model.Name),
            DataBaseHelper.RawSafeSglDecimal((decimal)model.Sum));
            var dataResult = DataBaseHelper.GetSqlResult(sql);
            if (dataResult != null && dataResult.Rows.Count > 0)
            {
                foreach (DataRow row in dataResult.Rows)
                {
                    ReceiptId = DataBaseHelper.GetIntegerValueFromRowByName(dataResult.Rows[0], "ReceiptId");
                }
            }

            return ReceiptId;
        }

        public static ReceiptDto GetReceiptDtoId(int id)
        {
            ReceiptDto result = new ReceiptDto();

            var sql = string.Format(@"EXEC [sp_GetReceiptDetailID] {0}",
               DataBaseHelper.RawSafeSqlString(id));
            var sqlResult = DataBaseHelper.GetSqlResult(sql);

            if (sqlResult.Rows.Count > 0)
            {
                result = new ReceiptDto
                {
                    Id = DataBaseHelper.GetIntegerValueFromRowByName(sqlResult.Rows[0], "ReceiptId"),
                    Name = DataBaseHelper.GetValueFromRowByName(sqlResult.Rows[0], "Name"),
                    Sum = DataBaseHelper.GetDecimalValueFromRowByName(sqlResult.Rows[0], "Sum")
                };
            }

            return result;
        }

        public static void DeleteReceipt(int id)
        {
            if (id > 0)
            {
                string sql = string.Format(@"exec sp_RemoveReceipt {0}",
                DataBaseHelper.RawSafeSqlString(id));
                DataBaseHelper.RunSql(sql);
            }
        }
    }
}
