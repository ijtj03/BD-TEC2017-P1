package com.example.jeison.farmacy;

import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.TextView;
import android.widget.Toast;

import com.example.jeison.farmacy.MedicinasFragment.OnListFragmentInteractionListener;
import com.example.jeison.farmacy.dummy.DummyContent.DummyItem;

import java.util.List;

/**
 * {@link RecyclerView.Adapter} that can display a {@link DummyItem} and makes a call to the
 * specified {@link OnListFragmentInteractionListener}.
 * TODO: Replace the implementation with code for your data type.
 */
public class MedicinasAdapter extends RecyclerView.Adapter<MedicinasAdapter.ViewHolder> {

    private final List<Medicinas> mValues;
    private final OnListFragmentInteractionListener mListener;

    public MedicinasAdapter(List<Medicinas> items, OnListFragmentInteractionListener listener) {
        mValues = items;
        mListener = listener;
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext())
                .inflate(R.layout.fragment_medicinas, parent, false);
        return new ViewHolder(view);
    }

    @Override
    public void onBindViewHolder(final ViewHolder holder, int position) {
        holder.mItem = mValues.get(position);
        holder.mName.setText(mValues.get(position).mName);
        holder.mPrice.setText(mValues.get(position).mPrice);
        holder.mDescripcion.setText(mValues.get(position).mDescripcion);
        holder.mCantidad.setText(mValues.get(position).mCantidad);
        mValues.get(position).mViewm=holder.mView;

        holder.mAdd.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                boolean checked=holder.mAdd.isChecked();
                mListener.onListFragmentInteraction(holder.mItem,checked,holder.mView);
            }
        });
        holder.mView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (null != mListener) {
                    // Notify the active callbacks interface (the activity, if the
                    // fragment is attached to one) that an item has been selected.
                    mListener.onListFragmentInteraction(holder.mItem,false,null);
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return mValues.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder {
        public final View mView;
        public final TextView mName;
        public final TextView mPrice;
        public final TextView mDescripcion;
        public final TextView mCantidad;
        public final CheckBox mAdd;
        public Medicinas mItem;

        public ViewHolder(View view) {
            super(view);
            mView = view;
            mName = (TextView) view.findViewById(R.id.name);
            mPrice = (TextView) view.findViewById(R.id.price);
            mDescripcion= (TextView) view.findViewById(R.id.descripcion);
            mCantidad= (TextView) view.findViewById(R.id.cantidad);
            mAdd= (CheckBox) view.findViewById(R.id.check_add);
        }

        @Override
        public String toString() {
            return super.toString() + " '" + mName.getText() + "'";
        }
    }
}
