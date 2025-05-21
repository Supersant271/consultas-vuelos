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
    public IActionResult Consulta2(string avion){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.TipoAvion,avion);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta3")]
    public IActionResult Consulta3(int cupo){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Gt(x => x.CupoAvion,cupo);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta4")]
    public IActionResult Consulta4(string pais){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.PaisOrigen,pais);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta5")]
    public IActionResult Consulta5([FromQuery]List<string> pais){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Nin(x => x.PaisDestino,pais);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta6")]
    public IActionResult Consulta6(int pasa){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Lt(x => x.PasajerosActuales,pasa);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta7")]
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
    [HttpGet("consulta8")]
    public IActionResult Consulta8(string avion, int pasa){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.TipoAvion,avion);
        var filtros = Builders<Aeropuerto>.Filter.Lte(x => x.PasajerosActuales,pasa);

        var filtrocompuesto = Builders<Aeropuerto>.Filter.And(filtro, filtros);
        var lista = collection.Find(filtrocompuesto).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta9")]
    public IActionResult Consulta9(string nombre,[FromQuery]List <string> pais){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.NombrePiloto,nombre);
        var filtros = Builders<Aeropuerto>.Filter.In(x => x.PaisDestino,pais);

        var filtrocompuesto = Builders<Aeropuerto>.Filter.And(filtro, filtros);
        var lista = collection.Find(filtrocompuesto).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta10")]
    public IActionResult Consulta10(string pais, [FromQuery]List<string>ciudad){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.PaisDestino,pais);
        var filtros = Builders<Aeropuerto>.Filter.Nin(x => x.CiudadOrigen,ciudad);

        var filtrocompuesto = Builders<Aeropuerto>.Filter.And(filtro, filtros);
        var lista = collection.Find(filtrocompuesto).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta11")]
    public IActionResult Consulta11(string pais1,string pais2, string estatus){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.PaisOrigen,pais1);
        var filtrod = Builders<Aeropuerto>.Filter.Eq(x => x.PaisDestino,pais2);
        var filtroa = Builders<Aeropuerto>.Filter.Eq(x => x.EstatusVuelo,estatus);

        var filtrocompuesto = Builders<Aeropuerto>.Filter.And(filtro, filtrod,filtroa);
        var lista = collection.Find(filtrocompuesto).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta12")]
    public IActionResult Consulta12(string avion){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.TipoAvion,avion);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta13")]
    public IActionResult Consulta13(string avion){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.TipoAvion,avion);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta14")]
    public IActionResult Consulta14(string avion){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.TipoAvion,avion);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta15")]
    public IActionResult Consulta15(string avion){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.TipoAvion,avion);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta16")]
    public IActionResult Consulta16(string avion){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.TipoAvion,avion);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta17")]
    public IActionResult Consulta17(string avion){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.TipoAvion,avion);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
    [HttpGet("consulta18")]
    public IActionResult Consulta18(string avion){
        //listar todos los terrenos
        MongoClient client = new MongoClient(CadenaConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Eq(x => x.TipoAvion,avion);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
}