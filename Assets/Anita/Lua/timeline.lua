function timeline(timelime_name, time)
    time = time or 0
    __Anita.timelineController:SetTimelinePrefab(timelime_name)
    local playableDirector = __Anita.timelineController.playableDirector
    if playableDirector then
        playableDirector.time = time
        playableDirector:Evaluate()
    end
end
add_preload_pattern_with_obj('timeline', '__Anita.timelineController')

function timeline_hide()
    __Anita.timelineController:ClearTimelinePrefab()
    schedule_gc()
end

function timeline_seek(time)
    local playableDirector = __Anita.timelineController.playableDirector
    if playableDirector then
        playableDirector.time = time
        playableDirector:Evaluate()
    else
        warn('playableDirector not found')
    end
end

make_anim_method('timeline_play', function(self, to, duration, slope)
    local obj = __Anita.timelineController
    to = to or obj.playableDirector.duration
    duration = duration or to - obj.playableDirector.time
    slope = slope or {1, 1}
    local easing = parse_easing(slope)
    return self:_then(Anita.TimeAnimationProperty(obj, to)):_with(easing):_for(duration)
end)
