using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

public class DataGridViewPasswordTextBoxCell : System.Windows.Forms.DataGridViewTextBoxCell
{

    private char _passwordChar;

    private bool _useSystemPasswordChar;
    private char editingControlPasswordChar;

    private bool editingControlUseSystemPasswordChar;
    public char PasswordChar
    {
        get { return this._passwordChar; }
        set { this._passwordChar = value; }
    }

    public bool UseSystemPasswordChar
    {
        get { return this._useSystemPasswordChar; }
        set { this._useSystemPasswordChar = value; }
    }

    public override object Clone()
    {
        DataGridViewPasswordTextBoxCell copy = (DataGridViewPasswordTextBoxCell)base.Clone();

        copy.PasswordChar = this._passwordChar;
        copy.UseSystemPasswordChar = this._useSystemPasswordChar;

        return copy;
    }

    protected override object GetFormattedValue(object value, int rowIndex, ref System.Windows.Forms.DataGridViewCellStyle cellStyle, System.ComponentModel.TypeConverter valueTypeConverter, System.ComponentModel.TypeConverter formattedValueTypeConverter, System.Windows.Forms.DataGridViewDataErrorContexts context)
    {
        object formattedValue = null;

        if (this._useSystemPasswordChar && value != null)
        {
            //Display the system password character in place of each actual character.
            //TODO: Determine the actual system password character instead of hard-coding this value.
            formattedValue = new string(Convert.ToChar(0x25cf), Convert.ToString(value).Length);
        }
        else if (this._passwordChar != char.MinValue && value != null)
        {
            //Display the user-defined password character in place of each actual character.
            formattedValue = new string(this._passwordChar, Convert.ToString(value).Length);
        }
        else
        {
            //Display the value as is.
            formattedValue = base.GetFormattedValue(value, rowIndex, ref cellStyle, valueTypeConverter, formattedValueTypeConverter, context);
        }

        return formattedValue;
    }

    public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle)
    {
        base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);

        var _with1 = (TextBox)this.DataGridView.EditingControl;
        //Remember the current password properties of the editing control.
        this.editingControlPasswordChar = _with1.PasswordChar;
        this.editingControlUseSystemPasswordChar = _with1.UseSystemPasswordChar;

        //Set the new password properties of the editing control.
        _with1.PasswordChar = this._passwordChar;
        _with1.UseSystemPasswordChar = this._useSystemPasswordChar;
    }

    public override void DetachEditingControl()
    {
        base.DetachEditingControl();

        var _with2 = (TextBox)this.DataGridView.EditingControl;
        //Reset the old password properties of the editing control.
        _with2.PasswordChar = this.editingControlPasswordChar;
        _with2.UseSystemPasswordChar = this.editingControlUseSystemPasswordChar;
    }

}
