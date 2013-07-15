﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.296
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Serialization;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Darili")]
public partial class Darili_LinqDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region 可扩展性方法定义
  partial void OnCreated();
  partial void InsertEvent_BM(Event_BM instance);
  partial void UpdateEvent_BM(Event_BM instance);
  partial void DeleteEvent_BM(Event_BM instance);
  partial void InsertEvent_LectureEx(Event_LectureEx instance);
  partial void UpdateEvent_LectureEx(Event_LectureEx instance);
  partial void DeleteEvent_LectureEx(Event_LectureEx instance);
  partial void InsertEvent_MultipleTime(Event_MultipleTime instance);
  partial void UpdateEvent_MultipleTime(Event_MultipleTime instance);
  partial void DeleteEvent_MultipleTime(Event_MultipleTime instance);
  partial void InsertEventMain(EventMain instance);
  partial void UpdateEventMain(EventMain instance);
  partial void DeleteEventMain(EventMain instance);
  partial void InsertLecture(Lecture instance);
  partial void UpdateLecture(Lecture instance);
  partial void DeleteLecture(Lecture instance);
  #endregion
	
	public Darili_LinqDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["416ConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public Darili_LinqDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public Darili_LinqDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public Darili_LinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public Darili_LinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Event_BM> Event_BM
	{
		get
		{
			return this.GetTable<Event_BM>();
		}
	}
	
	public System.Data.Linq.Table<Event_LectureEx> Event_LectureEx
	{
		get
		{
			return this.GetTable<Event_LectureEx>();
		}
	}
	
	public System.Data.Linq.Table<Event_MultipleTime> Event_MultipleTime
	{
		get
		{
			return this.GetTable<Event_MultipleTime>();
		}
	}
	
	public System.Data.Linq.Table<EventMain> EventMain
	{
		get
		{
			return this.GetTable<EventMain>();
		}
	}
	
	public System.Data.Linq.Table<Lecture> Lecture
	{
		get
		{
			return this.GetTable<Lecture>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Event_BM")]
[global::System.Runtime.Serialization.DataContractAttribute()]
public partial class Event_BM : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _id;
	
	private System.DateTime _StartTime;
	
	private System.DateTime _EndTime;
	
	private System.Xml.Linq.XElement _detail;
	
	private System.Nullable<int> _numlimit;
	
	private EntityRef<EventMain> _EventMain;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnStartTimeChanging(System.DateTime value);
    partial void OnStartTimeChanged();
    partial void OnEndTimeChanging(System.DateTime value);
    partial void OnEndTimeChanged();
    partial void OndetailChanging(System.Xml.Linq.XElement value);
    partial void OndetailChanged();
    partial void OnnumlimitChanging(System.Nullable<int> value);
    partial void OnnumlimitChanged();
    #endregion
	
	public Event_BM()
	{
		this.Initialize();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
	public int id
	{
		get
		{
			return this._id;
		}
		set
		{
			if ((this._id != value))
			{
				if (this._EventMain.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnidChanging(value);
				this.SendPropertyChanging();
				this._id = value;
				this.SendPropertyChanged("id");
				this.OnidChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartTime", DbType="DateTime NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
	public System.DateTime StartTime
	{
		get
		{
			return this._StartTime;
		}
		set
		{
			if ((this._StartTime != value))
			{
				this.OnStartTimeChanging(value);
				this.SendPropertyChanging();
				this._StartTime = value;
				this.SendPropertyChanged("StartTime");
				this.OnStartTimeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndTime", DbType="DateTime NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
	public System.DateTime EndTime
	{
		get
		{
			return this._EndTime;
		}
		set
		{
			if ((this._EndTime != value))
			{
				this.OnEndTimeChanging(value);
				this.SendPropertyChanging();
				this._EndTime = value;
				this.SendPropertyChanged("EndTime");
				this.OnEndTimeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_detail", DbType="Xml", UpdateCheck=UpdateCheck.Never)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
	public System.Xml.Linq.XElement detail
	{
		get
		{
			return this._detail;
		}
		set
		{
			if ((this._detail != value))
			{
				this.OndetailChanging(value);
				this.SendPropertyChanging();
				this._detail = value;
				this.SendPropertyChanged("detail");
				this.OndetailChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_numlimit", DbType="Int")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
	public System.Nullable<int> numlimit
	{
		get
		{
			return this._numlimit;
		}
		set
		{
			if ((this._numlimit != value))
			{
				this.OnnumlimitChanging(value);
				this.SendPropertyChanging();
				this._numlimit = value;
				this.SendPropertyChanged("numlimit");
				this.OnnumlimitChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EventMain_Event_BM", Storage="_EventMain", ThisKey="id", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
	public EventMain EventMain
	{
		get
		{
			return this._EventMain.Entity;
		}
		set
		{
			EventMain previousValue = this._EventMain.Entity;
			if (((previousValue != value) 
						|| (this._EventMain.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._EventMain.Entity = null;
					previousValue.Event_BM = null;
				}
				this._EventMain.Entity = value;
				if ((value != null))
				{
					value.Event_BM = this;
					this._id = value.Id;
				}
				else
				{
					this._id = default(int);
				}
				this.SendPropertyChanged("EventMain");
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
	
	private void Initialize()
	{
		this._EventMain = default(EntityRef<EventMain>);
		OnCreated();
	}
	
	[global::System.Runtime.Serialization.OnDeserializingAttribute()]
	[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
	public void OnDeserializing(StreamingContext context)
	{
		this.Initialize();
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Event_LectureEx")]
[global::System.Runtime.Serialization.DataContractAttribute()]
public partial class Event_LectureEx : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _event_id;
	
	private string _Brand;
	
	private string _speakerinf;
	
	private EntityRef<EventMain> _EventMain;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onevent_idChanging(int value);
    partial void Onevent_idChanged();
    partial void OnBrandChanging(string value);
    partial void OnBrandChanged();
    partial void OnspeakerinfChanging(string value);
    partial void OnspeakerinfChanged();
    #endregion
	
	public Event_LectureEx()
	{
		this.Initialize();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_event_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
	public int event_id
	{
		get
		{
			return this._event_id;
		}
		set
		{
			if ((this._event_id != value))
			{
				if (this._EventMain.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.Onevent_idChanging(value);
				this.SendPropertyChanging();
				this._event_id = value;
				this.SendPropertyChanged("event_id");
				this.Onevent_idChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Brand", DbType="NVarChar(20)")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
	public string Brand
	{
		get
		{
			return this._Brand;
		}
		set
		{
			if ((this._Brand != value))
			{
				this.OnBrandChanging(value);
				this.SendPropertyChanging();
				this._Brand = value;
				this.SendPropertyChanged("Brand");
				this.OnBrandChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_speakerinf", DbType="NVarChar(MAX)")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
	public string speakerinf
	{
		get
		{
			return this._speakerinf;
		}
		set
		{
			if ((this._speakerinf != value))
			{
				this.OnspeakerinfChanging(value);
				this.SendPropertyChanging();
				this._speakerinf = value;
				this.SendPropertyChanged("speakerinf");
				this.OnspeakerinfChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EventMain_Event_LectureEx", Storage="_EventMain", ThisKey="event_id", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
	public EventMain EventMain
	{
		get
		{
			return this._EventMain.Entity;
		}
		set
		{
			EventMain previousValue = this._EventMain.Entity;
			if (((previousValue != value) 
						|| (this._EventMain.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._EventMain.Entity = null;
					previousValue.Event_LectureEx = null;
				}
				this._EventMain.Entity = value;
				if ((value != null))
				{
					value.Event_LectureEx = this;
					this._event_id = value.Id;
				}
				else
				{
					this._event_id = default(int);
				}
				this.SendPropertyChanged("EventMain");
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
	
	private void Initialize()
	{
		this._EventMain = default(EntityRef<EventMain>);
		OnCreated();
	}
	
	[global::System.Runtime.Serialization.OnDeserializingAttribute()]
	[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
	public void OnDeserializing(StreamingContext context)
	{
		this.Initialize();
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Event_MultipleTime")]
[global::System.Runtime.Serialization.DataContractAttribute()]
public partial class Event_MultipleTime : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Event_Id;
	
	private System.DateTime _StartDate;
	
	private bool _IsRoutine;
	
	private System.DateTime _EndDate;
	
	private int _SubTime_Id;
	
	private string _routine;
	
	private EntityRef<EventMain> _EventMain;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEvent_IdChanging(int value);
    partial void OnEvent_IdChanged();
    partial void OnStartDateChanging(System.DateTime value);
    partial void OnStartDateChanged();
    partial void OnIsRoutineChanging(bool value);
    partial void OnIsRoutineChanged();
    partial void OnEndDateChanging(System.DateTime value);
    partial void OnEndDateChanged();
    partial void OnSubTime_IdChanging(int value);
    partial void OnSubTime_IdChanged();
    partial void OnroutineChanging(string value);
    partial void OnroutineChanged();
    #endregion
	
	public Event_MultipleTime()
	{
		this.Initialize();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Event_Id", DbType="Int NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
	public int Event_Id
	{
		get
		{
			return this._Event_Id;
		}
		set
		{
			if ((this._Event_Id != value))
			{
				if (this._EventMain.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnEvent_IdChanging(value);
				this.SendPropertyChanging();
				this._Event_Id = value;
				this.SendPropertyChanged("Event_Id");
				this.OnEvent_IdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartDate", DbType="DateTime NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
	public System.DateTime StartDate
	{
		get
		{
			return this._StartDate;
		}
		set
		{
			if ((this._StartDate != value))
			{
				this.OnStartDateChanging(value);
				this.SendPropertyChanging();
				this._StartDate = value;
				this.SendPropertyChanged("StartDate");
				this.OnStartDateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsRoutine", DbType="Bit NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
	public bool IsRoutine
	{
		get
		{
			return this._IsRoutine;
		}
		set
		{
			if ((this._IsRoutine != value))
			{
				this.OnIsRoutineChanging(value);
				this.SendPropertyChanging();
				this._IsRoutine = value;
				this.SendPropertyChanged("IsRoutine");
				this.OnIsRoutineChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndDate", DbType="DateTime NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
	public System.DateTime EndDate
	{
		get
		{
			return this._EndDate;
		}
		set
		{
			if ((this._EndDate != value))
			{
				this.OnEndDateChanging(value);
				this.SendPropertyChanging();
				this._EndDate = value;
				this.SendPropertyChanged("EndDate");
				this.OnEndDateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubTime_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
	public int SubTime_Id
	{
		get
		{
			return this._SubTime_Id;
		}
		set
		{
			if ((this._SubTime_Id != value))
			{
				this.OnSubTime_IdChanging(value);
				this.SendPropertyChanging();
				this._SubTime_Id = value;
				this.SendPropertyChanged("SubTime_Id");
				this.OnSubTime_IdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_routine", DbType="NChar(10)")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
	public string routine
	{
		get
		{
			return this._routine;
		}
		set
		{
			if ((this._routine != value))
			{
				this.OnroutineChanging(value);
				this.SendPropertyChanging();
				this._routine = value;
				this.SendPropertyChanged("routine");
				this.OnroutineChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EventMain_Event_MultipleTime", Storage="_EventMain", ThisKey="Event_Id", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
	public EventMain EventMain
	{
		get
		{
			return this._EventMain.Entity;
		}
		set
		{
			EventMain previousValue = this._EventMain.Entity;
			if (((previousValue != value) 
						|| (this._EventMain.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._EventMain.Entity = null;
					previousValue.Event_MultipleTime.Remove(this);
				}
				this._EventMain.Entity = value;
				if ((value != null))
				{
					value.Event_MultipleTime.Add(this);
					this._Event_Id = value.Id;
				}
				else
				{
					this._Event_Id = default(int);
				}
				this.SendPropertyChanged("EventMain");
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
	
	private void Initialize()
	{
		this._EventMain = default(EntityRef<EventMain>);
		OnCreated();
	}
	
	[global::System.Runtime.Serialization.OnDeserializingAttribute()]
	[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
	public void OnDeserializing(StreamingContext context)
	{
		this.Initialize();
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.EventMain")]
[global::System.Runtime.Serialization.DataContractAttribute()]
public partial class EventMain : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private System.DateTime _StartTime;
	
	private System.DateTime _EndTime;
	
	private System.DateTime _PublishTime;
	
	private System.DateTime _LastModified;
	
	private string _Publisher;
	
	private short _ViewFlag;
	
	private string _Type;
	
	private string _Title;
	
	private string _Location;
	
	private string _Context;
	
	private System.Xml.Linq.XElement _Subscription;
	
	private string _Subtitle;
	
	private string _SubType;
	
	private string _Series;
	
	private EntityRef<Event_BM> _Event_BM;
	
	private EntityRef<Event_LectureEx> _Event_LectureEx;
	
	private EntitySet<Event_MultipleTime> _Event_MultipleTime;
	
	private EntitySet<Lecture> _Lecture;
	
	private bool serializing;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnStartTimeChanging(System.DateTime value);
    partial void OnStartTimeChanged();
    partial void OnEndTimeChanging(System.DateTime value);
    partial void OnEndTimeChanged();
    partial void OnPublishTimeChanging(System.DateTime value);
    partial void OnPublishTimeChanged();
    partial void OnLastModifiedChanging(System.DateTime value);
    partial void OnLastModifiedChanged();
    partial void OnPublisherChanging(string value);
    partial void OnPublisherChanged();
    partial void OnViewFlagChanging(short value);
    partial void OnViewFlagChanged();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnLocationChanging(string value);
    partial void OnLocationChanged();
    partial void OnContextChanging(string value);
    partial void OnContextChanged();
    partial void OnSubscriptionChanging(System.Xml.Linq.XElement value);
    partial void OnSubscriptionChanged();
    partial void OnSubtitleChanging(string value);
    partial void OnSubtitleChanged();
    partial void OnSubTypeChanging(string value);
    partial void OnSubTypeChanged();
    partial void OnSeriesChanging(string value);
    partial void OnSeriesChanged();
    #endregion
	
	public EventMain()
	{
		this.Initialize();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_StartTime", DbType="DateTime NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
	public System.DateTime StartTime
	{
		get
		{
			return this._StartTime;
		}
		set
		{
			if ((this._StartTime != value))
			{
				this.OnStartTimeChanging(value);
				this.SendPropertyChanging();
				this._StartTime = value;
				this.SendPropertyChanged("StartTime");
				this.OnStartTimeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EndTime", DbType="DateTime NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
	public System.DateTime EndTime
	{
		get
		{
			return this._EndTime;
		}
		set
		{
			if ((this._EndTime != value))
			{
				this.OnEndTimeChanging(value);
				this.SendPropertyChanging();
				this._EndTime = value;
				this.SendPropertyChanged("EndTime");
				this.OnEndTimeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PublishTime", DbType="DateTime NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
	public System.DateTime PublishTime
	{
		get
		{
			return this._PublishTime;
		}
		set
		{
			if ((this._PublishTime != value))
			{
				this.OnPublishTimeChanging(value);
				this.SendPropertyChanging();
				this._PublishTime = value;
				this.SendPropertyChanged("PublishTime");
				this.OnPublishTimeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModified", DbType="DateTime NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=5)]
	public System.DateTime LastModified
	{
		get
		{
			return this._LastModified;
		}
		set
		{
			if ((this._LastModified != value))
			{
				this.OnLastModifiedChanging(value);
				this.SendPropertyChanging();
				this._LastModified = value;
				this.SendPropertyChanged("LastModified");
				this.OnLastModifiedChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Publisher", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=6)]
	public string Publisher
	{
		get
		{
			return this._Publisher;
		}
		set
		{
			if ((this._Publisher != value))
			{
				this.OnPublisherChanging(value);
				this.SendPropertyChanging();
				this._Publisher = value;
				this.SendPropertyChanged("Publisher");
				this.OnPublisherChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ViewFlag", DbType="SmallInt NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=7)]
	public short ViewFlag
	{
		get
		{
			return this._ViewFlag;
		}
		set
		{
			if ((this._ViewFlag != value))
			{
				this.OnViewFlagChanging(value);
				this.SendPropertyChanging();
				this._ViewFlag = value;
				this.SendPropertyChanged("ViewFlag");
				this.OnViewFlagChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="NVarChar(20) NOT NULL", CanBeNull=false)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=8)]
	public string Type
	{
		get
		{
			return this._Type;
		}
		set
		{
			if ((this._Type != value))
			{
				this.OnTypeChanging(value);
				this.SendPropertyChanging();
				this._Type = value;
				this.SendPropertyChanged("Type");
				this.OnTypeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=9)]
	public string Title
	{
		get
		{
			return this._Title;
		}
		set
		{
			if ((this._Title != value))
			{
				this.OnTitleChanging(value);
				this.SendPropertyChanging();
				this._Title = value;
				this.SendPropertyChanged("Title");
				this.OnTitleChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Location", DbType="NVarChar(30) NOT NULL", CanBeNull=false)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=10)]
	public string Location
	{
		get
		{
			return this._Location;
		}
		set
		{
			if ((this._Location != value))
			{
				this.OnLocationChanging(value);
				this.SendPropertyChanging();
				this._Location = value;
				this.SendPropertyChanged("Location");
				this.OnLocationChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Context", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=11)]
	public string Context
	{
		get
		{
			return this._Context;
		}
		set
		{
			if ((this._Context != value))
			{
				this.OnContextChanging(value);
				this.SendPropertyChanging();
				this._Context = value;
				this.SendPropertyChanged("Context");
				this.OnContextChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subscription", DbType="Xml", UpdateCheck=UpdateCheck.Never)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=12)]
	public System.Xml.Linq.XElement Subscription
	{
		get
		{
			return this._Subscription;
		}
		set
		{
			if ((this._Subscription != value))
			{
				this.OnSubscriptionChanging(value);
				this.SendPropertyChanging();
				this._Subscription = value;
				this.SendPropertyChanged("Subscription");
				this.OnSubscriptionChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subtitle", DbType="NVarChar(50)")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=13)]
	public string Subtitle
	{
		get
		{
			return this._Subtitle;
		}
		set
		{
			if ((this._Subtitle != value))
			{
				this.OnSubtitleChanging(value);
				this.SendPropertyChanging();
				this._Subtitle = value;
				this.SendPropertyChanged("Subtitle");
				this.OnSubtitleChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubType", DbType="NVarChar(20)")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=14)]
	public string SubType
	{
		get
		{
			return this._SubType;
		}
		set
		{
			if ((this._SubType != value))
			{
				this.OnSubTypeChanging(value);
				this.SendPropertyChanging();
				this._SubType = value;
				this.SendPropertyChanged("SubType");
				this.OnSubTypeChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Series", DbType="NVarChar(20)")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=15)]
	public string Series
	{
		get
		{
			return this._Series;
		}
		set
		{
			if ((this._Series != value))
			{
				this.OnSeriesChanging(value);
				this.SendPropertyChanging();
				this._Series = value;
				this.SendPropertyChanged("Series");
				this.OnSeriesChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EventMain_Event_BM", Storage="_Event_BM", ThisKey="Id", OtherKey="id", IsUnique=true, IsForeignKey=false)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=16, EmitDefaultValue=false)]
	public Event_BM Event_BM
	{
		get
		{
			if ((this.serializing 
						&& (this._Event_BM.HasLoadedOrAssignedValue == false)))
			{
				return null;
			}
			return this._Event_BM.Entity;
		}
		set
		{
			Event_BM previousValue = this._Event_BM.Entity;
			if (((previousValue != value) 
						|| (this._Event_BM.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Event_BM.Entity = null;
					previousValue.EventMain = null;
				}
				this._Event_BM.Entity = value;
				if ((value != null))
				{
					value.EventMain = this;
				}
				this.SendPropertyChanged("Event_BM");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EventMain_Event_LectureEx", Storage="_Event_LectureEx", ThisKey="Id", OtherKey="event_id", IsUnique=true, IsForeignKey=false)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=17, EmitDefaultValue=false)]
	public Event_LectureEx Event_LectureEx
	{
		get
		{
			if ((this.serializing 
						&& (this._Event_LectureEx.HasLoadedOrAssignedValue == false)))
			{
				return null;
			}
			return this._Event_LectureEx.Entity;
		}
		set
		{
			Event_LectureEx previousValue = this._Event_LectureEx.Entity;
			if (((previousValue != value) 
						|| (this._Event_LectureEx.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Event_LectureEx.Entity = null;
					previousValue.EventMain = null;
				}
				this._Event_LectureEx.Entity = value;
				if ((value != null))
				{
					value.EventMain = this;
				}
				this.SendPropertyChanged("Event_LectureEx");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EventMain_Event_MultipleTime", Storage="_Event_MultipleTime", ThisKey="Id", OtherKey="Event_Id")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=18, EmitDefaultValue=false)]
	public EntitySet<Event_MultipleTime> Event_MultipleTime
	{
		get
		{
			if ((this.serializing 
						&& (this._Event_MultipleTime.HasLoadedOrAssignedValues == false)))
			{
				return null;
			}
			return this._Event_MultipleTime;
		}
		set
		{
			this._Event_MultipleTime.Assign(value);
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EventMain_Lecture", Storage="_Lecture", ThisKey="Id", OtherKey="Event_Id")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=19, EmitDefaultValue=false)]
	public EntitySet<Lecture> Lecture
	{
		get
		{
			if ((this.serializing 
						&& (this._Lecture.HasLoadedOrAssignedValues == false)))
			{
				return null;
			}
			return this._Lecture;
		}
		set
		{
			this._Lecture.Assign(value);
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
	
	private void attach_Event_MultipleTime(Event_MultipleTime entity)
	{
		this.SendPropertyChanging();
		entity.EventMain = this;
	}
	
	private void detach_Event_MultipleTime(Event_MultipleTime entity)
	{
		this.SendPropertyChanging();
		entity.EventMain = null;
	}
	
	private void attach_Lecture(Lecture entity)
	{
		this.SendPropertyChanging();
		entity.EventMain = this;
	}
	
	private void detach_Lecture(Lecture entity)
	{
		this.SendPropertyChanging();
		entity.EventMain = null;
	}
	
	private void Initialize()
	{
		this._Event_BM = default(EntityRef<Event_BM>);
		this._Event_LectureEx = default(EntityRef<Event_LectureEx>);
		this._Event_MultipleTime = new EntitySet<Event_MultipleTime>(new Action<Event_MultipleTime>(this.attach_Event_MultipleTime), new Action<Event_MultipleTime>(this.detach_Event_MultipleTime));
		this._Lecture = new EntitySet<Lecture>(new Action<Lecture>(this.attach_Lecture), new Action<Lecture>(this.detach_Lecture));
		OnCreated();
	}
	
	[global::System.Runtime.Serialization.OnDeserializingAttribute()]
	[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
	public void OnDeserializing(StreamingContext context)
	{
		this.Initialize();
	}
	
	[global::System.Runtime.Serialization.OnSerializingAttribute()]
	[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
	public void OnSerializing(StreamingContext context)
	{
		this.serializing = true;
	}
	
	[global::System.Runtime.Serialization.OnSerializedAttribute()]
	[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
	public void OnSerialized(StreamingContext context)
	{
		this.serializing = false;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Lecture")]
[global::System.Runtime.Serialization.DataContractAttribute()]
public partial class Lecture : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Event_Id;
	
	private string _Speaker;
	
	private string _Class;
	
	private int _sub_id;
	
	private EntityRef<EventMain> _EventMain;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnEvent_IdChanging(int value);
    partial void OnEvent_IdChanged();
    partial void OnSpeakerChanging(string value);
    partial void OnSpeakerChanged();
    partial void OnClassChanging(string value);
    partial void OnClassChanged();
    partial void Onsub_idChanging(int value);
    partial void Onsub_idChanged();
    #endregion
	
	public Lecture()
	{
		this.Initialize();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Event_Id", DbType="Int NOT NULL")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=1)]
	public int Event_Id
	{
		get
		{
			return this._Event_Id;
		}
		set
		{
			if ((this._Event_Id != value))
			{
				if (this._EventMain.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnEvent_IdChanging(value);
				this.SendPropertyChanging();
				this._Event_Id = value;
				this.SendPropertyChanged("Event_Id");
				this.OnEvent_IdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Speaker", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=2)]
	public string Speaker
	{
		get
		{
			return this._Speaker;
		}
		set
		{
			if ((this._Speaker != value))
			{
				this.OnSpeakerChanging(value);
				this.SendPropertyChanging();
				this._Speaker = value;
				this.SendPropertyChanged("Speaker");
				this.OnSpeakerChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Class", DbType="NChar(10)")]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=3)]
	public string Class
	{
		get
		{
			return this._Class;
		}
		set
		{
			if ((this._Class != value))
			{
				this.OnClassChanging(value);
				this.SendPropertyChanging();
				this._Class = value;
				this.SendPropertyChanged("Class");
				this.OnClassChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sub_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	[global::System.Runtime.Serialization.DataMemberAttribute(Order=4)]
	public int sub_id
	{
		get
		{
			return this._sub_id;
		}
		set
		{
			if ((this._sub_id != value))
			{
				this.Onsub_idChanging(value);
				this.SendPropertyChanging();
				this._sub_id = value;
				this.SendPropertyChanged("sub_id");
				this.Onsub_idChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="EventMain_Lecture", Storage="_EventMain", ThisKey="Event_Id", OtherKey="Id", IsForeignKey=true, DeleteOnNull=true, DeleteRule="CASCADE")]
	public EventMain EventMain
	{
		get
		{
			return this._EventMain.Entity;
		}
		set
		{
			EventMain previousValue = this._EventMain.Entity;
			if (((previousValue != value) 
						|| (this._EventMain.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._EventMain.Entity = null;
					previousValue.Lecture.Remove(this);
				}
				this._EventMain.Entity = value;
				if ((value != null))
				{
					value.Lecture.Add(this);
					this._Event_Id = value.Id;
				}
				else
				{
					this._Event_Id = default(int);
				}
				this.SendPropertyChanged("EventMain");
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
	
	private void Initialize()
	{
		this._EventMain = default(EntityRef<EventMain>);
		OnCreated();
	}
	
	[global::System.Runtime.Serialization.OnDeserializingAttribute()]
	[global::System.ComponentModel.EditorBrowsableAttribute(EditorBrowsableState.Never)]
	public void OnDeserializing(StreamingContext context)
	{
		this.Initialize();
	}
}
#pragma warning restore 1591
