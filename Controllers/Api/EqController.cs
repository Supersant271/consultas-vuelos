using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/consulta")]
public class EqController : Controller {
    [HttpGet("consulta1")]
    public IActionResult Consulta1(string estatus){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.EstatusVuelo,estatus);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
  }
    [HttpGet("consulta2")]
    public IActionResult Consulta3(int cupo)
    {
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Gt(x => x.CupoAvion, cupo);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta3")]
    public IActionResult Consulta5([FromQuery]List<string> pais){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Nin(x => x.PaisDestino,pais);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    
    [HttpGet("consulta4")]
    public IActionResult Consulta7(string pais1, string pais2){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.PaisOrigen,pais1);
        var filtros = Builders<Aeropuerto>.Filter.Eq(x => x.PaisDestino,pais2);

        var filtrocompuesto = Builders<Aeropuerto>.Filter.And(filtro, filtros);
        var lista = collection.Find(filtrocompuesto).ToList();
        return Ok(lista);
   }
}