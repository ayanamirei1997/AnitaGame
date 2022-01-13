anim_persist_begun = false

function anim_persist_begin()
    anim_persist:stop()
    __Nova.checkpointHelper:RestrainCheckpoint(Nova.CheckpointHelper.WarningStepNumFromLastCheckpoint, true)
    anim_persist_begun = true
end

function anim_persist_end()
    anim_persist:stop()
    __Nova.checkpointHelper:RestrainCheckpoint(0, true)
    anim_persist_begun = false
end

function ensure_ckpt_on_next_dialogue()
    __Nova.checkpointHelper:EnsureCheckpointOnNextDialogue()
end
Nova.ScriptDialogueEntryParser.AddCheckpointPattern('anim_persist_begin', 'ensure_ckpt_on_next_dialogue')

function update_global_save()
    __Nova.checkpointHelper:UpdateGlobalSave()
end
