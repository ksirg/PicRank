﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PicRank.Web.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="picrankdb")]
	public partial class PicRankDBDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertPicture(Picture instance);
    partial void UpdatePicture(Picture instance);
    partial void DeletePicture(Picture instance);
    partial void InsertRanking(Ranking instance);
    partial void UpdateRanking(Ranking instance);
    partial void DeleteRanking(Ranking instance);
    partial void InsertDataSet(DataSet instance);
    partial void UpdateDataSet(DataSet instance);
    partial void DeleteDataSet(DataSet instance);
    partial void InsertGameParticipant(GameParticipant instance);
    partial void UpdateGameParticipant(GameParticipant instance);
    partial void DeleteGameParticipant(GameParticipant instance);
    partial void InsertGame(Game instance);
    partial void UpdateGame(Game instance);
    partial void DeleteGame(Game instance);
    #endregion
		
		public PicRankDBDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["picrankdbConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public PicRankDBDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PicRankDBDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PicRankDBDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PicRankDBDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Picture> Pictures
		{
			get
			{
				return this.GetTable<Picture>();
			}
		}
		
		public System.Data.Linq.Table<Ranking> Rankings
		{
			get
			{
				return this.GetTable<Ranking>();
			}
		}
		
		public System.Data.Linq.Table<DataSet> DataSets
		{
			get
			{
				return this.GetTable<DataSet>();
			}
		}
		
		public System.Data.Linq.Table<GameParticipant> GameParticipants
		{
			get
			{
				return this.GetTable<GameParticipant>();
			}
		}
		
		public System.Data.Linq.Table<Game> Games
		{
			get
			{
				return this.GetTable<Game>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.RandomPictures")]
		public ISingleResult<RandomPicturesResult> RandomPictures([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> picCount)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), picCount);
			return ((ISingleResult<RandomPicturesResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetPicForRanking")]
		public ISingleResult<GetPicForRankingResult> GetPicForRanking([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> picCount)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), picCount);
			return ((ISingleResult<GetPicForRankingResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.SimpleRanking")]
		public int SimpleRanking()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((int)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Pictures")]
	public partial class Picture : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _DataSetId;
		
		private string _Name;
		
		private string _FullPath;
		
		private EntitySet<Ranking> _Rankings;
		
		private EntitySet<GameParticipant> _GameParticipants;
		
		private EntitySet<Game> _Games;
		
		private EntityRef<DataSet> _DataSet;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnDataSetIdChanging(System.Nullable<int> value);
    partial void OnDataSetIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnFullPathChanging(string value);
    partial void OnFullPathChanged();
    #endregion
		
		public Picture()
		{
			this._Rankings = new EntitySet<Ranking>(new Action<Ranking>(this.attach_Rankings), new Action<Ranking>(this.detach_Rankings));
			this._GameParticipants = new EntitySet<GameParticipant>(new Action<GameParticipant>(this.attach_GameParticipants), new Action<GameParticipant>(this.detach_GameParticipants));
			this._Games = new EntitySet<Game>(new Action<Game>(this.attach_Games), new Action<Game>(this.detach_Games));
			this._DataSet = default(EntityRef<DataSet>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DataSetId", DbType="Int")]
		public System.Nullable<int> DataSetId
		{
			get
			{
				return this._DataSetId;
			}
			set
			{
				if ((this._DataSetId != value))
				{
					if (this._DataSet.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnDataSetIdChanging(value);
					this.SendPropertyChanging();
					this._DataSetId = value;
					this.SendPropertyChanged("DataSetId");
					this.OnDataSetIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(200)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullPath", DbType="VarChar(300)")]
		public string FullPath
		{
			get
			{
				return this._FullPath;
			}
			set
			{
				if ((this._FullPath != value))
				{
					this.OnFullPathChanging(value);
					this.SendPropertyChanging();
					this._FullPath = value;
					this.SendPropertyChanged("FullPath");
					this.OnFullPathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Picture_Ranking", Storage="_Rankings", ThisKey="Id", OtherKey="PicId")]
		public EntitySet<Ranking> Rankings
		{
			get
			{
				return this._Rankings;
			}
			set
			{
				this._Rankings.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Picture_GameParticipant", Storage="_GameParticipants", ThisKey="Id", OtherKey="PictureId")]
		public EntitySet<GameParticipant> GameParticipants
		{
			get
			{
				return this._GameParticipants;
			}
			set
			{
				this._GameParticipants.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Picture_Game", Storage="_Games", ThisKey="Id", OtherKey="BasePicId")]
		public EntitySet<Game> Games
		{
			get
			{
				return this._Games;
			}
			set
			{
				this._Games.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DataSet_Picture", Storage="_DataSet", ThisKey="DataSetId", OtherKey="Id", IsForeignKey=true)]
		public DataSet DataSet
		{
			get
			{
				return this._DataSet.Entity;
			}
			set
			{
				DataSet previousValue = this._DataSet.Entity;
				if (((previousValue != value) 
							|| (this._DataSet.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DataSet.Entity = null;
						previousValue.Pictures.Remove(this);
					}
					this._DataSet.Entity = value;
					if ((value != null))
					{
						value.Pictures.Add(this);
						this._DataSetId = value.Id;
					}
					else
					{
						this._DataSetId = default(Nullable<int>);
					}
					this.SendPropertyChanged("DataSet");
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
		
		private void attach_Rankings(Ranking entity)
		{
			this.SendPropertyChanging();
			entity.Picture = this;
		}
		
		private void detach_Rankings(Ranking entity)
		{
			this.SendPropertyChanging();
			entity.Picture = null;
		}
		
		private void attach_GameParticipants(GameParticipant entity)
		{
			this.SendPropertyChanging();
			entity.Picture = this;
		}
		
		private void detach_GameParticipants(GameParticipant entity)
		{
			this.SendPropertyChanging();
			entity.Picture = null;
		}
		
		private void attach_Games(Game entity)
		{
			this.SendPropertyChanging();
			entity.Picture = this;
		}
		
		private void detach_Games(Game entity)
		{
			this.SendPropertyChanging();
			entity.Picture = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Ranking")]
	public partial class Ranking : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _BasePicId;
		
		private int _PicId;
		
		private System.Nullable<int> _PlayedGames;
		
		private System.Nullable<int> _Wins;
		
		private System.Nullable<int> _Losses;
		
		private System.Nullable<int> _Draws;
		
		private System.Nullable<double> _Score;
		
		private EntityRef<Picture> _Picture;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnBasePicIdChanging(int value);
    partial void OnBasePicIdChanged();
    partial void OnPicIdChanging(int value);
    partial void OnPicIdChanged();
    partial void OnPlayedGamesChanging(System.Nullable<int> value);
    partial void OnPlayedGamesChanged();
    partial void OnWinsChanging(System.Nullable<int> value);
    partial void OnWinsChanged();
    partial void OnLossesChanging(System.Nullable<int> value);
    partial void OnLossesChanged();
    partial void OnDrawsChanging(System.Nullable<int> value);
    partial void OnDrawsChanged();
    partial void OnScoreChanging(System.Nullable<double> value);
    partial void OnScoreChanged();
    #endregion
		
		public Ranking()
		{
			this._Picture = default(EntityRef<Picture>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BasePicId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int BasePicId
		{
			get
			{
				return this._BasePicId;
			}
			set
			{
				if ((this._BasePicId != value))
				{
					this.OnBasePicIdChanging(value);
					this.SendPropertyChanging();
					this._BasePicId = value;
					this.SendPropertyChanged("BasePicId");
					this.OnBasePicIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PicId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int PicId
		{
			get
			{
				return this._PicId;
			}
			set
			{
				if ((this._PicId != value))
				{
					if (this._Picture.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPicIdChanging(value);
					this.SendPropertyChanging();
					this._PicId = value;
					this.SendPropertyChanged("PicId");
					this.OnPicIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayedGames", DbType="Int")]
		public System.Nullable<int> PlayedGames
		{
			get
			{
				return this._PlayedGames;
			}
			set
			{
				if ((this._PlayedGames != value))
				{
					this.OnPlayedGamesChanging(value);
					this.SendPropertyChanging();
					this._PlayedGames = value;
					this.SendPropertyChanged("PlayedGames");
					this.OnPlayedGamesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Wins", DbType="Int")]
		public System.Nullable<int> Wins
		{
			get
			{
				return this._Wins;
			}
			set
			{
				if ((this._Wins != value))
				{
					this.OnWinsChanging(value);
					this.SendPropertyChanging();
					this._Wins = value;
					this.SendPropertyChanged("Wins");
					this.OnWinsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Losses", DbType="Int")]
		public System.Nullable<int> Losses
		{
			get
			{
				return this._Losses;
			}
			set
			{
				if ((this._Losses != value))
				{
					this.OnLossesChanging(value);
					this.SendPropertyChanging();
					this._Losses = value;
					this.SendPropertyChanged("Losses");
					this.OnLossesChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Draws", DbType="Int")]
		public System.Nullable<int> Draws
		{
			get
			{
				return this._Draws;
			}
			set
			{
				if ((this._Draws != value))
				{
					this.OnDrawsChanging(value);
					this.SendPropertyChanging();
					this._Draws = value;
					this.SendPropertyChanged("Draws");
					this.OnDrawsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Score", DbType="Float")]
		public System.Nullable<double> Score
		{
			get
			{
				return this._Score;
			}
			set
			{
				if ((this._Score != value))
				{
					this.OnScoreChanging(value);
					this.SendPropertyChanging();
					this._Score = value;
					this.SendPropertyChanged("Score");
					this.OnScoreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Picture_Ranking", Storage="_Picture", ThisKey="PicId", OtherKey="Id", IsForeignKey=true)]
		public Picture Picture
		{
			get
			{
				return this._Picture.Entity;
			}
			set
			{
				Picture previousValue = this._Picture.Entity;
				if (((previousValue != value) 
							|| (this._Picture.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Picture.Entity = null;
						previousValue.Rankings.Remove(this);
					}
					this._Picture.Entity = value;
					if ((value != null))
					{
						value.Rankings.Add(this);
						this._PicId = value.Id;
					}
					else
					{
						this._PicId = default(int);
					}
					this.SendPropertyChanged("Picture");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DataSets")]
	public partial class DataSet : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Name;
		
		private string _FolderPath;
		
		private System.Nullable<int> _PicCoutn;
		
		private System.Nullable<bool> _Active;
		
		private EntitySet<Picture> _Pictures;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnFolderPathChanging(string value);
    partial void OnFolderPathChanged();
    partial void OnPicCoutnChanging(System.Nullable<int> value);
    partial void OnPicCoutnChanged();
    partial void OnActiveChanging(System.Nullable<bool> value);
    partial void OnActiveChanged();
    #endregion
		
		public DataSet()
		{
			this._Pictures = new EntitySet<Picture>(new Action<Picture>(this.attach_Pictures), new Action<Picture>(this.detach_Pictures));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="VarChar(200)")]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FolderPath", DbType="VarChar(300)")]
		public string FolderPath
		{
			get
			{
				return this._FolderPath;
			}
			set
			{
				if ((this._FolderPath != value))
				{
					this.OnFolderPathChanging(value);
					this.SendPropertyChanging();
					this._FolderPath = value;
					this.SendPropertyChanged("FolderPath");
					this.OnFolderPathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PicCoutn", DbType="Int")]
		public System.Nullable<int> PicCoutn
		{
			get
			{
				return this._PicCoutn;
			}
			set
			{
				if ((this._PicCoutn != value))
				{
					this.OnPicCoutnChanging(value);
					this.SendPropertyChanging();
					this._PicCoutn = value;
					this.SendPropertyChanged("PicCoutn");
					this.OnPicCoutnChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit")]
		public System.Nullable<bool> Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DataSet_Picture", Storage="_Pictures", ThisKey="Id", OtherKey="DataSetId")]
		public EntitySet<Picture> Pictures
		{
			get
			{
				return this._Pictures;
			}
			set
			{
				this._Pictures.Assign(value);
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
		
		private void attach_Pictures(Picture entity)
		{
			this.SendPropertyChanging();
			entity.DataSet = this;
		}
		
		private void detach_Pictures(Picture entity)
		{
			this.SendPropertyChanging();
			entity.DataSet = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.GameParticipants")]
	public partial class GameParticipant : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _GameId;
		
		private int _PictureId;
		
		private bool _IsWinner;
		
		private EntityRef<Picture> _Picture;
		
		private EntityRef<Game> _Game;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnGameIdChanging(int value);
    partial void OnGameIdChanged();
    partial void OnPictureIdChanging(int value);
    partial void OnPictureIdChanged();
    partial void OnIsWinnerChanging(bool value);
    partial void OnIsWinnerChanged();
    #endregion
		
		public GameParticipant()
		{
			this._Picture = default(EntityRef<Picture>);
			this._Game = default(EntityRef<Game>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GameId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int GameId
		{
			get
			{
				return this._GameId;
			}
			set
			{
				if ((this._GameId != value))
				{
					if (this._Game.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnGameIdChanging(value);
					this.SendPropertyChanging();
					this._GameId = value;
					this.SendPropertyChanged("GameId");
					this.OnGameIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PictureId", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int PictureId
		{
			get
			{
				return this._PictureId;
			}
			set
			{
				if ((this._PictureId != value))
				{
					if (this._Picture.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnPictureIdChanging(value);
					this.SendPropertyChanging();
					this._PictureId = value;
					this.SendPropertyChanged("PictureId");
					this.OnPictureIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsWinner", DbType="Bit NOT NULL")]
		public bool IsWinner
		{
			get
			{
				return this._IsWinner;
			}
			set
			{
				if ((this._IsWinner != value))
				{
					this.OnIsWinnerChanging(value);
					this.SendPropertyChanging();
					this._IsWinner = value;
					this.SendPropertyChanged("IsWinner");
					this.OnIsWinnerChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Picture_GameParticipant", Storage="_Picture", ThisKey="PictureId", OtherKey="Id", IsForeignKey=true)]
		public Picture Picture
		{
			get
			{
				return this._Picture.Entity;
			}
			set
			{
				Picture previousValue = this._Picture.Entity;
				if (((previousValue != value) 
							|| (this._Picture.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Picture.Entity = null;
						previousValue.GameParticipants.Remove(this);
					}
					this._Picture.Entity = value;
					if ((value != null))
					{
						value.GameParticipants.Add(this);
						this._PictureId = value.Id;
					}
					else
					{
						this._PictureId = default(int);
					}
					this.SendPropertyChanged("Picture");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Game_GameParticipant", Storage="_Game", ThisKey="GameId", OtherKey="Id", IsForeignKey=true)]
		public Game Game
		{
			get
			{
				return this._Game.Entity;
			}
			set
			{
				Game previousValue = this._Game.Entity;
				if (((previousValue != value) 
							|| (this._Game.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Game.Entity = null;
						previousValue.GameParticipants.Remove(this);
					}
					this._Game.Entity = value;
					if ((value != null))
					{
						value.GameParticipants.Add(this);
						this._GameId = value.Id;
					}
					else
					{
						this._GameId = default(int);
					}
					this.SendPropertyChanged("Game");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Games")]
	public partial class Game : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private System.Nullable<int> _BasePicId;
		
		private System.Nullable<System.DateTime> _GameDate;
		
		private bool _IsFinished;
		
		private EntitySet<GameParticipant> _GameParticipants;
		
		private EntityRef<Picture> _Picture;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnBasePicIdChanging(System.Nullable<int> value);
    partial void OnBasePicIdChanged();
    partial void OnGameDateChanging(System.Nullable<System.DateTime> value);
    partial void OnGameDateChanged();
    partial void OnIsFinishedChanging(bool value);
    partial void OnIsFinishedChanged();
    #endregion
		
		public Game()
		{
			this._GameParticipants = new EntitySet<GameParticipant>(new Action<GameParticipant>(this.attach_GameParticipants), new Action<GameParticipant>(this.detach_GameParticipants));
			this._Picture = default(EntityRef<Picture>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BasePicId", DbType="Int")]
		public System.Nullable<int> BasePicId
		{
			get
			{
				return this._BasePicId;
			}
			set
			{
				if ((this._BasePicId != value))
				{
					if (this._Picture.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnBasePicIdChanging(value);
					this.SendPropertyChanging();
					this._BasePicId = value;
					this.SendPropertyChanged("BasePicId");
					this.OnBasePicIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GameDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> GameDate
		{
			get
			{
				return this._GameDate;
			}
			set
			{
				if ((this._GameDate != value))
				{
					this.OnGameDateChanging(value);
					this.SendPropertyChanging();
					this._GameDate = value;
					this.SendPropertyChanged("GameDate");
					this.OnGameDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsFinished", DbType="Bit NOT NULL")]
		public bool IsFinished
		{
			get
			{
				return this._IsFinished;
			}
			set
			{
				if ((this._IsFinished != value))
				{
					this.OnIsFinishedChanging(value);
					this.SendPropertyChanging();
					this._IsFinished = value;
					this.SendPropertyChanged("IsFinished");
					this.OnIsFinishedChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Game_GameParticipant", Storage="_GameParticipants", ThisKey="Id", OtherKey="GameId")]
		public EntitySet<GameParticipant> GameParticipants
		{
			get
			{
				return this._GameParticipants;
			}
			set
			{
				this._GameParticipants.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Picture_Game", Storage="_Picture", ThisKey="BasePicId", OtherKey="Id", IsForeignKey=true)]
		public Picture Picture
		{
			get
			{
				return this._Picture.Entity;
			}
			set
			{
				Picture previousValue = this._Picture.Entity;
				if (((previousValue != value) 
							|| (this._Picture.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Picture.Entity = null;
						previousValue.Games.Remove(this);
					}
					this._Picture.Entity = value;
					if ((value != null))
					{
						value.Games.Add(this);
						this._BasePicId = value.Id;
					}
					else
					{
						this._BasePicId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Picture");
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
		
		private void attach_GameParticipants(GameParticipant entity)
		{
			this.SendPropertyChanging();
			entity.Game = this;
		}
		
		private void detach_GameParticipants(GameParticipant entity)
		{
			this.SendPropertyChanging();
			entity.Game = null;
		}
	}
	
	public partial class RandomPicturesResult
	{
		
		private int _Id;
		
		private string _FullPath;
		
		public RandomPicturesResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL")]
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
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullPath", DbType="VarChar(300)")]
		public string FullPath
		{
			get
			{
				return this._FullPath;
			}
			set
			{
				if ((this._FullPath != value))
				{
					this._FullPath = value;
				}
			}
		}
	}
	
	public partial class GetPicForRankingResult
	{
		
		private int _Id;
		
		private string _FullPath;
		
		private System.Nullable<int> _PlayedGames;
		
		public GetPicForRankingResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL")]
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
					this._Id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullPath", DbType="VarChar(300)")]
		public string FullPath
		{
			get
			{
				return this._FullPath;
			}
			set
			{
				if ((this._FullPath != value))
				{
					this._FullPath = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PlayedGames", DbType="Int")]
		public System.Nullable<int> PlayedGames
		{
			get
			{
				return this._PlayedGames;
			}
			set
			{
				if ((this._PlayedGames != value))
				{
					this._PlayedGames = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
