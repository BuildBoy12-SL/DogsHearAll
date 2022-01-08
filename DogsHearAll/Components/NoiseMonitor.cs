// -----------------------------------------------------------------------
// <copyright file="NoiseMonitor.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace DogsHearAll.Components
{
    using Exiled.API.Features;
    using UnityEngine;

    /// <summary>
    /// Updates a player's noise level when speaking.
    /// </summary>
    public class NoiseMonitor : MonoBehaviour
    {
        private Player player;
        private float noise;

        private void Awake()
        {
            player = Player.Get(gameObject);
            noise = Plugin.Instance.Config.Intensity;
            if (player == null)
                Destroy(this);
        }

        private void FixedUpdate()
        {
            if (player.IsHuman && (player.Radio.UsingVoiceChat || player.Radio.UsingRadio))
                player.ReferenceHub.footstepSync._visionController.MakeNoise(noise);
        }
    }
}