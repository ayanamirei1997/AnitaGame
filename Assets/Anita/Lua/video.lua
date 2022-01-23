function video(video_name)
    __Anita.videoController:SetVideo(video_name)
end

function video_hide()
    __Anita.videoController:ClearVideo()
    schedule_gc()
end

make_anim_method('video_play', function(self, duration)
    local videoPlayer = __Anita.videoController.videoPlayer
    duration = duration or videoPlayer.clip.length
    return self:action(function() videoPlayer:Play() end):wait(duration)
end)
