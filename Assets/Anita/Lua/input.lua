function input_on()
    __Anita.inputHelper:EnableInput()
end

function input_off()
    __Anita.inputHelper:DisableInput()
end

function click_forward_on()
    __Anita.dialogueBoxController.canClickForward = true
end

function click_forward_off()
    __Anita.dialogueBoxController.canClickForward = false
end

function click_abort_anim_on()
    __Anita.dialogueBoxController.scriptCanAbortAnimation = true
end

function click_abort_anim_off()
    __Anita.dialogueBoxController.scriptCanAbortAnimation = false
end
