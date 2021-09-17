// -----------------------------------------------------------------------
// <copyright file="NoiseMonitor.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace DogsHearAll.Components
{
    using System;
    using Exiled.API.Features;
    using UnityEngine;

    /// <summary>
    /// Updates a player's noise level when speaking.
    /// </summary>
    public class NoiseMonitor : MonoBehaviour
    {
        private Player player;
        private Radio radio;
        private float noise;

        /// <summary>
        /// Destroys the component safely.
        /// </summary>
        public void Destroy()
        {
            try
            {
                Destroy(this);
            }
            catch (Exception e)
            {
                Log.Error($"Failed to destroy {nameof(NoiseMonitor)}!\n{e}");
            }
        }

        private void Awake()
        {
            player = Player.Get(gameObject);
            noise = Plugin.Instance.Config.Intensity;
            if (player == null || !player.GameObject.TryGetComponent(out radio))
                Destroy();
        }

        private void FixedUpdate()
        {
            if (player.IsHuman && (radio.UsingVoiceChat || radio.UsingRadio))
                player.ReferenceHub.footstepSync._visionController.MakeNoise(noise);
        }
    }
}