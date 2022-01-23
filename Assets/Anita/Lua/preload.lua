add_preload_pattern = Anita.ScriptDialogueEntryParser.AddPattern
add_preload_pattern_with_obj = Anita.ScriptDialogueEntryParser.AddPatternWithObject
add_preload_pattern_for_table = Anita.ScriptDialogueEntryParser.AddPatternForTable
add_preload_pattern_with_obj_for_table = Anita.ScriptDialogueEntryParser.AddPatternWithObjectForTable
add_preload_pattern_with_obj_and_res = Anita.ScriptDialogueEntryParser.AddPatternWithObjectAndResource

function preload(obj, resource_name)
    if obj == nil then
        warn('Preload obj == nil', resource_name)
    end

    if obj == 'Texture' then
        Anita.AssetLoader.Preload(Anita.AssetCacheType.Image, resource_name)
    elseif obj == __Anita.timelineController then
        Anita.AssetLoader.Preload(Anita.AssetCacheType.Timeline, obj.timelinePrefabFolder .. '/' .. resource_name)
    elseif tostring(obj:GetType()) == 'Anita.AudioController' then
        obj:Preload(resource_name)
    else
        if type(resource_name) == 'table' then
            obj:PreloadPose(resource_name)
        else
            local pose = get_pose(obj, resource_name)
            if pose then
                obj:PreloadPose(pose)
            else
                Anita.AssetLoader.Preload(Anita.AssetCacheType.Image, obj.imageFolder .. '/' .. resource_name)
            end
        end
    end
end

function unpreload(obj, resource_name)
    if obj == nil then
        warn('Unpreload obj == nil', resource_name)
    end

    if obj == 'Texture' then
        Anita.AssetLoader.Unpreload(Anita.AssetCacheType.Image, resource_name)
    elseif obj == __Anita.timelineController then
        Anita.AssetLoader.Unpreload(Anita.AssetCacheType.Timeline, obj.timelinePrefabFolder .. '/' .. resource_name)
    elseif tostring(obj:GetType()) == 'Anita.AudioController' then
        obj:Unpreload(resource_name)
    else
        if type(resource_name) == 'table' then
            obj:UnpreloadPose(resource_name)
        else
            local pose = get_pose(obj, resource_name)
            if pose then
                obj:UnpreloadPose(pose)
            else
                Anita.AssetLoader.Unpreload(Anita.AssetCacheType.Image, obj.imageFolder .. '/' .. resource_name)
            end
        end
    end
end

function need_preload(obj, resource_name)
end
add_preload_pattern('need_preload')
