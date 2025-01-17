﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using PluginCore.Interfaces;
using PluginCore.IPlugins;
using PluginCore.Utils;

namespace PluginCore.BackgroundServices
{
    public class PluginTimeJobBackgroundService : TimeBackgroundService
    {
        /// <summary>
        /// 插件与之最近执行时间
        /// <para>最近执行时间: 10位秒 时间戳</para>
        /// </summary>
        private readonly Dictionary<string, long> _pluginAndLastExecuteTimeDic = new Dictionary<string, long>();

        private readonly IPluginFinder _pluginFinder;

        public PluginTimeJobBackgroundService(IPluginFinder pluginFinder)
        {
            _pluginFinder = pluginFinder;
            // 最小间隔 1 秒
            _timerPeriod = TimeSpan.FromSeconds(1);
        }

        protected override void DoWork(object state)
        {
            var plugins = this._pluginFinder.EnablePlugins<ITimeJobPlugin>().ToList();

            List<string> enabledPluginKeyList = new List<string>();
            foreach (var item in plugins)
            {
                string pluginKey = item.GetType().ToString();
                enabledPluginKeyList.Add(pluginKey);
                if (this._pluginAndLastExecuteTimeDic.ContainsKey(pluginKey))
                {
                    long lastExecuteTime = this._pluginAndLastExecuteTimeDic[pluginKey];
                    long nowTime = DateTime.Now.ToTimeStamp10();
                    if (nowTime - lastExecuteTime >= item.SecondsPeriod)
                    {
                        // 调用
                        Utils.LogUtil.Info($"{pluginKey} {nameof(ITimeJobPlugin)}.{nameof(ITimeJobPlugin.ExecuteAsync)}");
                        Task task = item?.ExecuteAsync();
                        this._pluginAndLastExecuteTimeDic[pluginKey] = DateTime.Now.ToTimeStamp10();
                    }
                }
                else
                {
                    // 调用
                    Utils.LogUtil.Info($"{pluginKey} {nameof(ITimeJobPlugin)}.{nameof(ITimeJobPlugin.ExecuteAsync)}");
                    Task task = item?.ExecuteAsync();
                    this._pluginAndLastExecuteTimeDic.Add(pluginKey, DateTime.Now.ToTimeStamp10());
                }
            }
            // 所有插件遍历结束
            // 出现在了 _pluginAndLastExecuteTimeDic 中，但没有出现在 enabledPluginKeyList, 说明为之前启用过，但现在已禁用的插件，需要去除掉
            List<string> keys = this._pluginAndLastExecuteTimeDic.Select(m => m.Key).ToList();
            foreach (string key in keys)
            {
                if (!enabledPluginKeyList.Contains(key))
                {
                    this._pluginAndLastExecuteTimeDic.Remove(key);
                }
            }

        }
    }
}
