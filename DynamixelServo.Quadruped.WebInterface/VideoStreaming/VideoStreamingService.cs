﻿using Microsoft.AspNetCore.Hosting;

namespace DynamixelServo.Quadruped.WebInterface.VideoStreaming
{
    public class VideoStreamingService : IVideoService
    {

        public string Port { get; private set; }
        public bool StreamRunning { get; private set; }

        public VideoStreamingService(IApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStopping.Register(KillStream);
            int port = 8080;
            BashCommand
                .Command($"nohup mjpg_streamer -o \"output_http.so -p {port}\" -i \"input_raspicam.so -x 1280 -y 720 -fps 10\" &")
                .Execute();
            var ip = BashCommand.Command("hostname -i").Execute();
            Port = $"http://{ip}:{port}/?action=stream";
            StreamRunning = true;
        }

        public void KillStream()
        {
            BashCommand
                .Command("pkill mjpg_streamer")
                .Execute();
            StreamRunning = false;
            Port = string.Empty;
        }
    }
}