using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using Library.Common;
using Library.Common.Data;

namespace Library.Framework.Layers
{
    [Serializable]
    public abstract class LogicEntity : Logic
    {
        public LogicEntity(string paramEntityName,
            string paramTableName, string paramConnectionStringName)
            : base (paramEntityName,
            paramTableName, paramConnectionStringName)
        {
        }

        public new AccessEntity DA
        {
            get
            {
                return (AccessEntity)base.DA;
            }
        }

        protected virtual bool ValidateInsert(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            return ValidateInsertModel(paramDE, ref paramField, ref paramMessage);
        }
        protected virtual bool ValidateUpdate(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            return ValidateUpdateModel(paramDE, ref paramField, ref paramMessage);
        }
        protected virtual bool ValidateDelete(Entity paramDE, ref string paramField, ref string paramMessage, bool paramValidateCascadeIntergrity = true)
        {
            return ValidateDeleteModel(paramDE, ref paramField, ref paramMessage);
        }
        
        protected virtual bool ValidateInsertModel(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            return true;
        }
        protected virtual bool ValidateUpdateModel(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            return true;
        }
        protected virtual bool ValidateDeleteModel(Entity paramDE, ref string paramField, ref string paramMessage, bool paramValidateCascadeIntergrity = true)
        {
            return true;
        }

        //antes de grabar
        public virtual bool ValidateSave(Entity paramDE, ref string paramField, ref string paramMessage)
        {
            bool bOk = true;

            if (bOk)
            {
                if (paramDE.Loaded)
                    bOk = ValidateUpdate(paramDE, ref paramField, ref paramMessage);
                else
                    bOk = ValidateInsert(paramDE, ref paramField, ref paramMessage);
            }

            return bOk;
        }
        public virtual bool ValidateErase(Entity paramDE, ref string paramField, ref string paramMessage, bool paramValidateCascadeIntegrity = true)
        {
            bool bOk = true;

            bOk = ValidateDelete(paramDE, ref paramField, ref paramMessage, paramValidateCascadeIntegrity);

            return bOk;
        }
        
        //despues de grabar
        public virtual bool VerifySave(Entity paramDE, bool paramIsSourceColumn = false)
        {
            return VerifySaveModel(paramDE, paramIsSourceColumn);
        }
        public virtual bool VerifyErase(Entity paramDE, bool paramIsSourceColumn = false)
        {
            return VerifyEraseModel(paramDE, paramIsSourceColumn);
        }

        public virtual bool VerifySaveModel(Entity paramDE, bool paramIsSourceColumn = false)
        {
            bool bOk = true;

            return bOk;
        }
        public virtual bool VerifyEraseModel(Entity paramDE, bool paramIsSourceColumn = false)
        {
            bool bOk = true;

            return bOk;
        }

        //comandos
        public virtual byte Save(Entity paramDE, bool paramCheckKeyEmpty = true, bool paramIsSourceColumn = false)
        {
            return SaveModel(paramDE, paramCheckKeyEmpty, paramIsSourceColumn);
        }
        public virtual byte Erase(Entity paramDE, bool paramCheckKeyEmpty = true, bool paramIsSourceColumn = false)
        {
            return EraseModel(paramDE, paramCheckKeyEmpty, paramIsSourceColumn);
        }
        public virtual byte Load(Entity paramDE, bool paramCheckKeyEmpty = true, bool paramIsSourceColumn = false, TypeLoad paramTypeLoad = TypeLoad.DataReader)
        {
            return LoadModel(paramDE, paramCheckKeyEmpty, paramIsSourceColumn);
        }

        public virtual byte SaveModel(Entity paramDE, bool paramCheckKeyEmpty = true, bool paramIsSourceColumn = false)
        {
            bool bKeyEmpty = DA.KeyIsEmpty(paramDE);
            if (paramDE.Loaded && paramCheckKeyEmpty && bKeyEmpty)
                return 2;
            else
                return Convert.ToByte(DA.Save(paramDE, bKeyEmpty, paramIsSourceColumn));
        }
        public virtual byte EraseModel(Entity paramDE, bool paramCheckKeyEmpty = true, bool paramIsSourceColumn = false)
        {
            bool bKeyEmpty = DA.KeyIsEmpty(paramDE);
            if (paramDE.Loaded && paramCheckKeyEmpty && bKeyEmpty)
                return 2;
            else
                return Convert.ToByte(DA.Erase(paramDE, bKeyEmpty, paramIsSourceColumn));
        }
        public virtual byte LoadModel(Entity paramDE, bool paramCheckKeyEmpty = true, bool paramIsSourceColumn = false, TypeLoad paramTypeLoad = TypeLoad.DataReader)
        {
            byte ret = 2;
            bool bIsKeyEmpty = DA.KeyIsEmpty(paramDE);

            if ((paramCheckKeyEmpty && !bIsKeyEmpty) || !paramCheckKeyEmpty)
                ret = Convert.ToByte(DA.Load(paramDE, bIsKeyEmpty, paramIsSourceColumn, paramTypeLoad));
            if (!((paramCheckKeyEmpty && !bIsKeyEmpty) || !paramCheckKeyEmpty) || ret == 0) 
                DA.Clear(paramDE);

            return ret;
        }

        public virtual void Clear(Entity paramDE)
        {
            DA.Clear(paramDE);
        }
        public virtual bool KeyIsEmpty(Entity paramDE)
        {
            return DA.KeyIsEmpty(paramDE);
        }

        public virtual int Count(Entity paramDE, bool IsKeyEmpty = true, string paramTableName = null)
        {
            if (string.IsNullOrWhiteSpace(paramTableName))
                paramTableName = DA.TableName;
            return Database.GetDataTable(DA.ConnectionStringName, DA.GetCommandSelect(paramDE, IsKeyEmpty), string.Empty).Rows.Count;
        }

        public DataTable GetDataCombo(Entity paramDE, 
            string paramValueName, string paramDisplayName, bool paramAddBlank = false, 
            bool paramIsSourceColumn = false, string paramTableName = null)
        {
            if (string.IsNullOrWhiteSpace(paramTableName))
                paramTableName = DA.TableName;
            return Database.GetDataCombo(DA.ConnectionStringName, GetCommandSelect(paramDE, paramIsSourceColumn), paramTableName, paramValueName, paramDisplayName, paramAddBlank); 
        }
        public DataTable GetDataTable(Entity paramDE, 
            bool paramIsSourceColumn = false, string paramTableName = null)
        {
            if (string.IsNullOrWhiteSpace(paramTableName))
                paramTableName = DA.TableName;
            return Database.GetDataTable(DA.ConnectionStringName, GetCommandSelect(paramDE, paramIsSourceColumn), paramTableName);
        }

        public DbDataAdapter FillDataSet(DataSet paramDataSet, Entity paramDE, 
            bool paramIsSourceColumn = false, 
            string paramTableName = null, 
            bool paramClear = true, 
            Dictionary<string, object> paramAdapterParameterValues = null,
            bool paramEmpty = false)
        {
            if (string.IsNullOrWhiteSpace(paramTableName))
                paramTableName = DA.TableName;
            return Database.FillDataSet(DA.ConnectionStringName, paramDataSet, GetDataAdapterSelect(paramDE, paramIsSourceColumn), 
                paramTableName, 
                paramClear, 
                ParameterField(paramAdapterParameterValues),
                paramEmpty);
        }
        public DbDataAdapter FillDataTable(DataTable paramDataTable, Entity paramDE, 
            bool paramIsSourceColumn = false,
            bool paramClear = true, 
            Dictionary<string, object> paramAdapterParameterValues = null,
            bool paramEmpty = false)
        {
            return Database.FillDataTable(DA.ConnectionStringName, paramDataTable, GetDataAdapterSelect(paramDE, paramIsSourceColumn), 
                paramClear, 
                ParameterField(paramAdapterParameterValues),
                paramEmpty);
        }

        public DbCommand GetCommandSelect(Entity paramDE, bool IsKeyEmpty, bool paramIsSourceColumn = false)
        {
            return DA.GetCommandSelect(paramDE, IsKeyEmpty, paramIsSourceColumn);
        }
        public DbDataAdapter GetDataAdapterSelect(Entity paramDE, bool IsKeyEmpty, bool paramIsSourceColumn = false, Dictionary<string, object> paramAdapterParameterValues = null)
        {
            return DA.GetDataAdapterSelect(paramDE, IsKeyEmpty, paramIsSourceColumn, ParameterField(paramAdapterParameterValues));
        }

        public Entity LoadEntityRow(DataRow paramRow, Entity paramDE)
        {
            return DA.LoadEntityRow(paramRow, paramDE);
        }
        public Entity LoadEntityReader(DbDataReader paramReader, Entity paramDE)
        {
            return DA.LoadEntityReader(paramReader, paramDE);
        }
    }
}
