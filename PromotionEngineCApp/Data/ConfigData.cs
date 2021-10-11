using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using PromotionEngineCApp;
using PromotionEngineCApp.Interface;



public class ConfigData : IConfigData
{
    IConfiguration configuration;


    public ConfigData()
    {
        try
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(Constants.DataSource, false);

            configuration = builder.Build();
        }
        catch (UnauthorizedAccessException ex)
        {
            LogFile.LogWrite("Error in Config file Loading :" + ex.Message);
        }
        catch (Exception ex)
        {

            LogFile.LogWrite("Error in Config file Loading :" + ex.Message);
        }

    }


    public List<Product> GetAvilableProducts()
    {
        List<Product> productList = new List<Product>();

        foreach (var item in configuration.GetSection(Constants.Products).GetChildren())
        {
            Product product = new Product();
            configuration.GetSection(item.Path).Bind(product);
            productList.Add(product);
        }

        return productList;
    }

    public List<Promotion> GetProductOffers()
    {
        List<Promotion> lst = new List<Promotion>();
        foreach (var item in configuration.GetSection(Constants.Promotions).GetChildren())
        {
            Promotion product = new Promotion();
            configuration.GetSection(item.Path).Bind(product);
            lst.Add(product);
        }
        return lst;
    }
}