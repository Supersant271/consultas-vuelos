// ClientApp/index.tsx
importar Reaccionar de 'reaccionar';
importar { crearRaíz } de 'react-dom/cliente';
importar { componentes } de './componentes';

documento.añadirListener de eventos('DOMContentLoaded', () => {
  constante elemento raíz = documento.obtenerElementoPorId('react-root');
  si (!elemento raíz) devolver;

  constante nombreDeComponente = elemento raíz.obtenerAtributo('componente de datos');
  constante Datos de apoyo = elemento raíz.obtenerAtributo('propiedades de datos');

  si (!nombreDeComponente || !(nombreDeComponente en componentes)) {
    consola.error(`Componente "${nombreDeComponente}" no encontrado.`);
    devolver;
  }

  dejar accesorios = {};
  si (Datos de apoyo) {
    intentar {
      accesorios = JSON.analizar gramaticalmente(Datos de apoyo);
    } atrapar (mi) {
      consola.registro(Datos de apoyo);
      consola.error('Error al analizar data-props:', mi);
    }
  }

  constante Componente = componentes[nombreDeComponente];
  constante raíz = crearRaíz(elemento raíz);
  raíz.prestar(<Componente {...accesorios} />);
});