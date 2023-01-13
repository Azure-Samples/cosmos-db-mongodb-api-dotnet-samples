// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// ------------------------------------------------------------

// <using_directives> 
using MongoDB.Driver;
// </using_directives>

// <client_credentials> 
// New instance of CosmosClient class
var client = new MongoClient(Environment.GetEnvironmentVariable("COSMOS_CONNECTION_STRING"));
// </client_credentials>

// <new_database> 
// Database reference with creation if it does not already exist
var db = client.GetDatabase("adventure");

// </new_database>

// <new_collection> 
// Container reference with creation if it does not alredy exist
var _products = db.GetCollection<Product>("products");
// </new_collection>

// <new_item> 
// Create new object and upsert (create or replace) to container
_products.InsertOne(new Product(
    Guid.NewGuid().ToString(),
    "gear-surf-surfboards",
    "Yamba Surfboard", 
    12, 
    false
));
// </new_item>

// <read_item> 
// Read a single item from container
var product = (await _products.FindAsync(p => p.Name.Contains("Yamba"))).FirstOrDefault();
Console.WriteLine("Single product:");
Console.WriteLine(product.Name);
// </read_item>

// <query_items> 
// Read multiple items from container
_products.InsertOne(new Product(
    Guid.NewGuid().ToString(),
    "gear-surf-surfboards",
    "Sand Surfboard",
    4,
    false
));

var products = _products.AsQueryable().Where(p => p.Category == "gear-surf-surfboards");

Console.WriteLine("Multiple products:");
foreach (var prod in products)
{
    Console.WriteLine(prod.Name);
}
// </query_items>
