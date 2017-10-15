package com.example.jeison.farmacy;

import com.example.jeison.farmacy.Clases.Medicinas;

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
    String Direccion;

    public Pedidos(String numpedido,String sucursal,String drecojo,String direccion){
        this.numPedido=numpedido;
        this.Sucursal=sucursal;
        this.Dater=drecojo;
        this.Direccion=direccion;
    }
}
