namespace PedidosYa
{

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class CadeteriaController : ControllerBase
    {
        [HttpGet("pedidos")]
        public IActionResult GetPedidos()
        {
            return Ok(ServicioCadeteria.Instance.Cadeteria.ListadoPedidos);
        }

        [HttpGet("cadetes")]
        public IActionResult GetCadetes()
        {
            return Ok(ServicioCadeteria.Instance.Cadeteria.ListadoCadetes);
        }

        [HttpGet("informe")]
        public IActionResult GetInforme()
        {
            return Ok(new Informe(ServicioCadeteria.Instance.Cadeteria));
        }

        [HttpPost("pedidos")]
        public IActionResult AgregarPedido(Pedido pedido)
        {
            ServicioCadeteria.Instance.Cadeteria.AgregarPedido(pedido.ObservacionPedido, pedido.Cliente.Nombre, pedido.Cliente.Direccion, pedido.Cliente.Telefono, pedido.Cliente.DatosReferenciaDireccion);
            return NoContent();
        }

        [HttpPut("pedidos/{idPedido}/asignar/{idCadete}")]
        public IActionResult AsignarPedido(int idPedido, int idCadete) 
        {
            ServicioCadeteria.Instance.Cadeteria.AsignarCadeteAPedido(idCadete, idPedido);
            return NoContent();
        }

        [HttpPut("pedidos/{idPedido}/estado/{nuevoEstado}")]

        public IActionResult CambiarEstadoPedido(int idPedido, int nuevoEstado) 
        {
            ServicioCadeteria.Instance.Cadeteria.CambiarEstado(idPedido, nuevoEstado);
            return NoContent();
        }

        [HttpPut("pedidos/{idPedido}/cambiar/{idNuevoCadete}")]
        public IActionResult CambiarCadetePedido(int idPedido, int idNuevoCadete) 
        {
            ServicioCadeteria.Instance.Cadeteria.ReasignarPedidoCadete(idPedido, idNuevoCadete);
            return NoContent();
        }
    }
}

