using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;   

[Route("Api/Vuelos")] 

public class Vueloscontroller : ControllerBase {
    [HttpGet("Ciudades_origen")]
    public IActionResult CiudadesOrigen(){
        var client = new MongoClient (CadenaConexion.MONGO_DB);
        var db = client.GetDatabase ("Aeropuerto");
        var Collection = db.GetCollection<Vuelo>("Vuelos");

        var Lista = Collection.Distinct<string>("CiudadOrigen", FilterDefinition<Vuelo>.Empty).ToList();
        
        return Ok(Lista);
    }

    [HttpGet("Ciudades_destino")]
    public IActionResult CiudadesDestino(){
        var client = new MongoClient (CadenaConexion.MONGO_DB);
        var db = client.GetDatabase ("Aeropuerto");
        var Collection = db.GetCollection<Vuelo>("Vuelos");

        var Lista = Collection.Distinct<string>("CiudadDestino", FilterDefinition<Vuelo>.Empty).ToList();
        
        return Ok(Lista);   
     }

    [HttpGet("estatus")]
    public IActionResult ListarEstatus(){
 var client = new MongoClient (CadenaConexion.MONGO_DB);
        var db = client.GetDatabase ("Aeropuerto");
        var Collection = db.GetCollection<Vuelo>("Vuelos");

        var Lista = Collection.Distinct<string>("EstatusVuelo", FilterDefinition<Vuelo>.Empty).ToList();
        
        return Ok(Lista);    
     }

    [HttpGet("listar-vuelos")] 
    public ActionResult ListarVuelos (string? estatus, string? origen, string? destino) { 
        var client = new MongoClient (CadenaConexion.MONGO_DB); 
        var db = client.GetDatabase("Aeropuerto"); 
        var collection = db.GetCollection<Vuelo>("Vuelos"); 

        List<FilterDefinition<Vuelo>> filters = new List<FilterDefinition<Vuelo>>(); 

        if(!string.IsNullOrWhiteSpace (origen)) { 
            var filterOrigen = Builders<Vuelo>.Filter.Eq(x => x.CiudadOrigen, origen); 
            filters.Add(filterOrigen); 
         } 

        if(!string.IsNullOrWhiteSpace (estatus)) { 
            var filterEstatus = Builders<Vuelo>.Filter.Eq(x => x.EstatusVuelo, estatus); 
            filters.Add(filterEstatus); 
         } 

         if(!string.IsNullOrWhiteSpace (destino)) { 
            var filterEstatus = Builders<Vuelo>.Filter.Eq(x => x.CiudadDestino, origen); 
            filters.Add(filterDestino); 
         } 

        List<Vuelo> vuelos; 
        if(filters.Count > 0) { 
         var filter = Builders<Vuelo>.Filter.And(filters); 
         vuelos = collection.Find(filter).ToList(); 

        } 
        else { 
             vuelos = collection.Find(FilterDefinition<Vuelo>.Empty).ToList();
        }  


        return Ok(vuelos);
    }
}