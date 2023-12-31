﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CityDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new City();
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            City city = entity as City;
            city.ID = int.Parse(reader["ID"].ToString());
            city.Name = reader["cityName"].ToString();
            return city;
        }


        public CityList SelectAllCity()
        {
            command.CommandText = "SELECT * FROM tblCity";
            CityList list = new CityList(ExecuteCommand());
            return list;
        }

        public City SelectById(int id)
        {
            command.CommandText = $"SELECT * FROM tblCity WHERE ID={id}";
            CityList list = new CityList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            City city = entity as City;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@cityName", city.Name);
            command.Parameters.AddWithValue("@ID", city.ID);
        }

        public int InsertCity(City city)
        {
            command.CommandText = "INSERT INTO tblCity (cityName) VALUES (@cityName)";
            LoadParameters(city);
            return ExecuteCRUD();
        }
        public int UpdateCity(City city)
        {
            command.CommandText = "UPDATE tblCity SET cityName = @cityName WHERE ID = @ID";
            LoadParameters(city);
            return ExecuteCRUD();
        }
        public int DeleteCity(City city)
        {
            command.CommandText = "DELETE FROM tblCity WHERE ID =@ID";
            LoadParameters(city);
            return ExecuteCRUD();
        }


    }
}
