﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CAPNUOCTHUDUC.LinQ
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DocSoTD")]
	public partial class DocSoDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertB_T(B_T instance);
    partial void UpdateB_T(B_T instance);
    partial void DeleteB_T(B_T instance);
    #endregion
		
		public DocSoDataContext() : 
				base(global::CAPNUOCTHUDUC.Properties.Settings.Default.DocSoTDConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DocSoDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DocSoDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DocSoDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DocSoDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<B_T> B_Ts
		{
			get
			{
				return this.GetTable<B_T>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.B_T")]
	public partial class B_T : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Danhba;
		
		private string _Tenkh;
		
		private string _DiaChi;
		
		private string _Hieu;
		
		private System.Nullable<short> _Co;
		
		private string _SoThan;
		
		private System.Nullable<int> _CsBao;
		
		private System.Nullable<byte> _Loai;
		
		private System.Nullable<System.DateTime> _Ngaybao;
		
		private string _Nhanvien;
		
		private System.Nullable<System.DateTime> _Ngaythay;
		
		private string _HieuMoi;
		
		private System.Nullable<short> _CoMoi;
		
		private string _SoThanMoi;
		
		private string _Coude;
		
		private string _SoBK;
		
		private System.Nullable<int> _Csgo;
		
		private System.Nullable<int> _Csgan;
		
		private string _CoudeMoi;
		
		private System.Nullable<System.DateTime> _NgayCapNhat;
		
		private string _MALOTRINH;
		
		private System.Nullable<bool> _FL;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnDanhbaChanging(string value);
    partial void OnDanhbaChanged();
    partial void OnTenkhChanging(string value);
    partial void OnTenkhChanged();
    partial void OnDiaChiChanging(string value);
    partial void OnDiaChiChanged();
    partial void OnHieuChanging(string value);
    partial void OnHieuChanged();
    partial void OnCoChanging(System.Nullable<short> value);
    partial void OnCoChanged();
    partial void OnSoThanChanging(string value);
    partial void OnSoThanChanged();
    partial void OnCsBaoChanging(System.Nullable<int> value);
    partial void OnCsBaoChanged();
    partial void OnLoaiChanging(System.Nullable<byte> value);
    partial void OnLoaiChanged();
    partial void OnNgaybaoChanging(System.Nullable<System.DateTime> value);
    partial void OnNgaybaoChanged();
    partial void OnNhanvienChanging(string value);
    partial void OnNhanvienChanged();
    partial void OnNgaythayChanging(System.Nullable<System.DateTime> value);
    partial void OnNgaythayChanged();
    partial void OnHieuMoiChanging(string value);
    partial void OnHieuMoiChanged();
    partial void OnCoMoiChanging(System.Nullable<short> value);
    partial void OnCoMoiChanged();
    partial void OnSoThanMoiChanging(string value);
    partial void OnSoThanMoiChanged();
    partial void OnCoudeChanging(string value);
    partial void OnCoudeChanged();
    partial void OnSoBKChanging(string value);
    partial void OnSoBKChanged();
    partial void OnCsgoChanging(System.Nullable<int> value);
    partial void OnCsgoChanged();
    partial void OnCsganChanging(System.Nullable<int> value);
    partial void OnCsganChanged();
    partial void OnCoudeMoiChanging(string value);
    partial void OnCoudeMoiChanged();
    partial void OnNgayCapNhatChanging(System.Nullable<System.DateTime> value);
    partial void OnNgayCapNhatChanged();
    partial void OnMALOTRINHChanging(string value);
    partial void OnMALOTRINHChanged();
    partial void OnFLChanging(System.Nullable<bool> value);
    partial void OnFLChanged();
    #endregion
		
		public B_T()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Danhba", DbType="NChar(11)")]
		public string Danhba
		{
			get
			{
				return this._Danhba;
			}
			set
			{
				if ((this._Danhba != value))
				{
					this.OnDanhbaChanging(value);
					this.SendPropertyChanging();
					this._Danhba = value;
					this.SendPropertyChanged("Danhba");
					this.OnDanhbaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tenkh", DbType="VarChar(100)")]
		public string Tenkh
		{
			get
			{
				return this._Tenkh;
			}
			set
			{
				if ((this._Tenkh != value))
				{
					this.OnTenkhChanging(value);
					this.SendPropertyChanging();
					this._Tenkh = value;
					this.SendPropertyChanged("Tenkh");
					this.OnTenkhChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DiaChi", DbType="VarChar(200)")]
		public string DiaChi
		{
			get
			{
				return this._DiaChi;
			}
			set
			{
				if ((this._DiaChi != value))
				{
					this.OnDiaChiChanging(value);
					this.SendPropertyChanging();
					this._DiaChi = value;
					this.SendPropertyChanged("DiaChi");
					this.OnDiaChiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Hieu", DbType="VarChar(3)")]
		public string Hieu
		{
			get
			{
				return this._Hieu;
			}
			set
			{
				if ((this._Hieu != value))
				{
					this.OnHieuChanging(value);
					this.SendPropertyChanging();
					this._Hieu = value;
					this.SendPropertyChanged("Hieu");
					this.OnHieuChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Co", DbType="SmallInt")]
		public System.Nullable<short> Co
		{
			get
			{
				return this._Co;
			}
			set
			{
				if ((this._Co != value))
				{
					this.OnCoChanging(value);
					this.SendPropertyChanging();
					this._Co = value;
					this.SendPropertyChanged("Co");
					this.OnCoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoThan", DbType="VarChar(25)")]
		public string SoThan
		{
			get
			{
				return this._SoThan;
			}
			set
			{
				if ((this._SoThan != value))
				{
					this.OnSoThanChanging(value);
					this.SendPropertyChanging();
					this._SoThan = value;
					this.SendPropertyChanged("SoThan");
					this.OnSoThanChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CsBao", DbType="Int")]
		public System.Nullable<int> CsBao
		{
			get
			{
				return this._CsBao;
			}
			set
			{
				if ((this._CsBao != value))
				{
					this.OnCsBaoChanging(value);
					this.SendPropertyChanging();
					this._CsBao = value;
					this.SendPropertyChanged("CsBao");
					this.OnCsBaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Loai", DbType="TinyInt")]
		public System.Nullable<byte> Loai
		{
			get
			{
				return this._Loai;
			}
			set
			{
				if ((this._Loai != value))
				{
					this.OnLoaiChanging(value);
					this.SendPropertyChanging();
					this._Loai = value;
					this.SendPropertyChanged("Loai");
					this.OnLoaiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ngaybao", DbType="Date")]
		public System.Nullable<System.DateTime> Ngaybao
		{
			get
			{
				return this._Ngaybao;
			}
			set
			{
				if ((this._Ngaybao != value))
				{
					this.OnNgaybaoChanging(value);
					this.SendPropertyChanging();
					this._Ngaybao = value;
					this.SendPropertyChanged("Ngaybao");
					this.OnNgaybaoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nhanvien", DbType="VarChar(25)")]
		public string Nhanvien
		{
			get
			{
				return this._Nhanvien;
			}
			set
			{
				if ((this._Nhanvien != value))
				{
					this.OnNhanvienChanging(value);
					this.SendPropertyChanging();
					this._Nhanvien = value;
					this.SendPropertyChanged("Nhanvien");
					this.OnNhanvienChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Ngaythay", DbType="Date")]
		public System.Nullable<System.DateTime> Ngaythay
		{
			get
			{
				return this._Ngaythay;
			}
			set
			{
				if ((this._Ngaythay != value))
				{
					this.OnNgaythayChanging(value);
					this.SendPropertyChanging();
					this._Ngaythay = value;
					this.SendPropertyChanged("Ngaythay");
					this.OnNgaythayChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HieuMoi", DbType="VarChar(3)")]
		public string HieuMoi
		{
			get
			{
				return this._HieuMoi;
			}
			set
			{
				if ((this._HieuMoi != value))
				{
					this.OnHieuMoiChanging(value);
					this.SendPropertyChanging();
					this._HieuMoi = value;
					this.SendPropertyChanged("HieuMoi");
					this.OnHieuMoiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CoMoi", DbType="SmallInt")]
		public System.Nullable<short> CoMoi
		{
			get
			{
				return this._CoMoi;
			}
			set
			{
				if ((this._CoMoi != value))
				{
					this.OnCoMoiChanging(value);
					this.SendPropertyChanging();
					this._CoMoi = value;
					this.SendPropertyChanged("CoMoi");
					this.OnCoMoiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoThanMoi", DbType="VarChar(10)")]
		public string SoThanMoi
		{
			get
			{
				return this._SoThanMoi;
			}
			set
			{
				if ((this._SoThanMoi != value))
				{
					this.OnSoThanMoiChanging(value);
					this.SendPropertyChanging();
					this._SoThanMoi = value;
					this.SendPropertyChanged("SoThanMoi");
					this.OnSoThanMoiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Coude", DbType="VarChar(10)")]
		public string Coude
		{
			get
			{
				return this._Coude;
			}
			set
			{
				if ((this._Coude != value))
				{
					this.OnCoudeChanging(value);
					this.SendPropertyChanging();
					this._Coude = value;
					this.SendPropertyChanged("Coude");
					this.OnCoudeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SoBK", DbType="VarChar(20)")]
		public string SoBK
		{
			get
			{
				return this._SoBK;
			}
			set
			{
				if ((this._SoBK != value))
				{
					this.OnSoBKChanging(value);
					this.SendPropertyChanging();
					this._SoBK = value;
					this.SendPropertyChanged("SoBK");
					this.OnSoBKChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Csgo", DbType="Int")]
		public System.Nullable<int> Csgo
		{
			get
			{
				return this._Csgo;
			}
			set
			{
				if ((this._Csgo != value))
				{
					this.OnCsgoChanging(value);
					this.SendPropertyChanging();
					this._Csgo = value;
					this.SendPropertyChanged("Csgo");
					this.OnCsgoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Csgan", DbType="Int")]
		public System.Nullable<int> Csgan
		{
			get
			{
				return this._Csgan;
			}
			set
			{
				if ((this._Csgan != value))
				{
					this.OnCsganChanging(value);
					this.SendPropertyChanging();
					this._Csgan = value;
					this.SendPropertyChanged("Csgan");
					this.OnCsganChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CoudeMoi", DbType="VarChar(10)")]
		public string CoudeMoi
		{
			get
			{
				return this._CoudeMoi;
			}
			set
			{
				if ((this._CoudeMoi != value))
				{
					this.OnCoudeMoiChanging(value);
					this.SendPropertyChanging();
					this._CoudeMoi = value;
					this.SendPropertyChanged("CoudeMoi");
					this.OnCoudeMoiChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NgayCapNhat", DbType="DateTime")]
		public System.Nullable<System.DateTime> NgayCapNhat
		{
			get
			{
				return this._NgayCapNhat;
			}
			set
			{
				if ((this._NgayCapNhat != value))
				{
					this.OnNgayCapNhatChanging(value);
					this.SendPropertyChanging();
					this._NgayCapNhat = value;
					this.SendPropertyChanged("NgayCapNhat");
					this.OnNgayCapNhatChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MALOTRINH", DbType="VarChar(10)")]
		public string MALOTRINH
		{
			get
			{
				return this._MALOTRINH;
			}
			set
			{
				if ((this._MALOTRINH != value))
				{
					this.OnMALOTRINHChanging(value);
					this.SendPropertyChanging();
					this._MALOTRINH = value;
					this.SendPropertyChanged("MALOTRINH");
					this.OnMALOTRINHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FL", DbType="Bit")]
		public System.Nullable<bool> FL
		{
			get
			{
				return this._FL;
			}
			set
			{
				if ((this._FL != value))
				{
					this.OnFLChanging(value);
					this.SendPropertyChanging();
					this._FL = value;
					this.SendPropertyChanged("FL");
					this.OnFLChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
