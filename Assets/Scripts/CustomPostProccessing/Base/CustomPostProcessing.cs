using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace CPP{
    public enum CustomPostProcessInjectionPoint{
        AfterOpaqueAndSky,
        BeforePostProcess,
        AfterPostProcess
    }

    public abstract class CustomPostProcessing : VolumeComponent, IPostProcessComponent, IDisposable{
        // 注入点
        public virtual CustomPostProcessInjectionPoint InjectionPoint => CustomPostProcessInjectionPoint.AfterPostProcess;
        
        //  在注入点的顺序
        public virtual int OrderInInjectonPoint => 0;

        // 配置当前后处理
        public abstract void Setup();

        // 执行渲染
        public abstract void Render(CommandBuffer cmd, ref RenderingData renderingData, RTHandle source, RTHandle destination);

        #region IPostProcessComponent

        public abstract bool IsActive();

        public virtual bool IsTileCompatible() => false;

        #endregion

        #region IDisposable

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing) {
        }

        #endregion
    }
}