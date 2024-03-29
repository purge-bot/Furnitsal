﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DbQuery
{
    [Serializable]
    public class Query
    {
        public List<string> ExtraInformation = new List<string>();
        public byte ExecuteCode;
        public string SqlQuery { get; private set; }
        public DataTable TableResult;

        private readonly Dictionary<string, object> _paramAttr;

        [NonSerialized]
        public List<NpgsqlParameter> CollectionParameters;

        public Query(List<string> extraInformation = null)
        {
            SqlQuery = "";

            if (extraInformation != null)
                ExtraInformation = extraInformation;

            _paramAttr = new Dictionary<string, object>();
            CollectionParameters = new List<NpgsqlParameter>();
        }

        public void AddSql(string SQLText)
        {
            SqlQuery += SQLText;
        }

        public void AddParam(string paramName, object paramValue)
        {
            _paramAttr.Add(paramName, paramValue);
        }

        public void Clear()
        {
            ExtraInformation.Clear();
            CollectionParameters.Clear();
            _paramAttr.Clear();
            SqlQuery = null;
        }

        public byte[] ToBytes()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, this);
                return stream.ToArray();
            }
        }

        public static Query ToQuery(byte[] SerializedQuery)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(SerializedQuery))
            {
                Query query = (Query)formatter.Deserialize(stream);
                query.CreateParameters(query._paramAttr);
                return query;
            }
        }

        public void Execute(QueryExec executor)
        {
            if (executor is null)
            {
                throw new ArgumentNullException(nameof(executor));
            }

            executor.Execute(this);
        }

        private void CreateParameters(Dictionary<string, object> collectionParameters)
        {
            CollectionParameters = new List<NpgsqlParameter>();
            foreach (var item in collectionParameters)
            {
                NpgsqlParameter parameter = new NpgsqlParameter(item.Key, item.Value);
                CollectionParameters.Add(parameter);
            }
        }
    }
}

