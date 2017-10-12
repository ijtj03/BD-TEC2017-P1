package com.example.jeison.farmacy;

import android.animation.Animator;
import android.animation.AnimatorListenerAdapter;
import android.annotation.TargetApi;
import android.content.Intent;
import android.os.Build;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.MenuItem;
import android.view.View;
import android.widget.CheckBox;
import android.widget.FrameLayout;
import android.widget.ProgressBar;
import android.widget.Toast;

import com.google.gson.JsonArray;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import com.loopj.android.http.AsyncHttpClient;
import com.loopj.android.http.AsyncHttpResponseHandler;
import com.loopj.android.http.RequestParams;

import java.util.ArrayList;

public class MedicamentosActivity extends AppCompatActivity implements MedicinasFragment.OnListFragmentInteractionListener{

    private MedicinasFragment medicinasFragment;
    private String SucursalName;
    private String SucursalId;
    private FrameLayout container;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_medicamentos);
        container=(FrameLayout) findViewById(R.id.frame_container);
        medicinasFragment=new MedicinasFragment();
        SucursalName = getIntent().getStringExtra("Su_Name");
        SucursalId=getIntent().getStringExtra("Su_id");

        Bundle args=new Bundle();
        args.putString("ID",SucursalId);
        medicinasFragment.setArguments(args);
        getSupportFragmentManager().beginTransaction()
                .add(R.id.frame_container, medicinasFragment).commit();



        getSupportActionBar().setDisplayShowHomeEnabled(true);
        getSupportActionBar().setDisplayHomeAsUpEnabled(true);


    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item){
        int id=item.getItemId();
        if(id==android.R.id.home){
            this.finish();
        }
        return super.onOptionsItemSelected(item);
    }
    @Override
    public void onListFragmentInteraction(Medicinas item,boolean checked,View view) {
        MedicinasFragment articleFrag = (MedicinasFragment)
                getSupportFragmentManager().findFragmentById(R.id.medicinas_fragment);
        Toast.makeText(this,
                "Medicamento selecionado: \n" + item.mName,
                Toast.LENGTH_SHORT).show();
        if(checked){
            medicinasFragment.mPedidos.addMedicina(item);
        }
    }

    @Override
    public void onPedidoFragmentInteration(Medicinas item, boolean checked,View view) {
        if(!checked){
            CheckBox check=(CheckBox) item.mViewm.findViewById(R.id.check_add);
            check.setChecked(false);
            medicinasFragment.pedidos.removeView(view);
            medicinasFragment.mPedidos.delMedicina(item);
        }
    }

    @Override
    public void onTerminarPedidoInteration(String PedidoList) {
        Intent intent=new Intent(getApplicationContext(),PedidosConfigActivity.class);
        intent.putExtra("medicinas",PedidoList);
        intent.putExtra("Su_name",SucursalName);
        intent.putExtra("Su_id",SucursalId);
        Log.i("Information","hola estoy aqui");
        startActivity(intent);
    }
}
