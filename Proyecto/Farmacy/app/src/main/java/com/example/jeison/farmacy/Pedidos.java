package com.example.jeison.farmacy;

import java.util.List;

/**
 * Created by Jeison on 02/10/2017.
 */

public class Pedidos {
    public List<Medicinas> medicamentos;
    public boolean receta;
    String numPedido;
    String Sucursal;
    String Dater;

    public Pedidos(String numpedido,String sucursal,String drecojo){
        this.numPedido=numpedido;
        this.Sucursal=sucursal;
        this.Dater=drecojo;
    }
}
