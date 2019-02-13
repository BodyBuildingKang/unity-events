﻿using System;

public static class GlobalSimEventSystem
{
	private static EventEntity _globalEntity;

	static GlobalSimEventSystem()
	{
		_globalEntity = EventEntity.CreateEntity();
	}

	public static void Subscribe<T_Event>(Action<T_Event> callback) where T_Event : unmanaged
	{
		EventManagerDO.Subscribe(_globalEntity, callback, EventUpdateType.FixedUpdate);
	}
	
	public static void SubscribeWithJob<T_Job, T_Event>(T_Job job, Action<T_Job> onComplete) 
		where T_Job : struct, IJobForEvent<T_Event> 
		where T_Event : unmanaged
	{
		EventManagerDO.SubscribeWithJob<T_Job, T_Event>(_globalEntity, job, onComplete, EventUpdateType.FixedUpdate);
	}

	public static void Unsubscribe<T_Event>(Action<T_Event> callback) where T_Event : unmanaged
	{
		EventManagerDO.Unsubscribe(_globalEntity, callback, EventUpdateType.FixedUpdate);
	}
	
	public static void UnsubscribeWithJob<T_Job, T_Event>(Action<T_Job> onComplete) 
		where T_Job : struct, IJobForEvent<T_Event> 
		where T_Event : unmanaged
	{
		EventManagerDO.UnsubscribeWithJob<T_Job, T_Event>(_globalEntity, onComplete, EventUpdateType.FixedUpdate);
	}

	public static void SendEvent<T_Event>(T_Event ev) where T_Event : unmanaged
	{
		EventManagerDO.SendEvent(_globalEntity, ev, EventUpdateType.FixedUpdate);
	}
}
