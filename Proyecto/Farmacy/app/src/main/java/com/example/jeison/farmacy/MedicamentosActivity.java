package com.example.jeison.farmacy;

import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.CheckBox;
import android.widget.Toast;

public class MedicamentosActivity extends AppCompatActivity implements MedicinasFragment.OnListFragmentInteractionListener{

    private MedicinasFragment medicinasFragment;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_medicamentos);

        medicinasFragment=new MedicinasFragment();

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
}
