-- access variable at run time (lazy only)
-- value can be boolean, number, or string
-- get: v(name)
-- set: v(name, value)
function v(name, value)
    if value == nil then
        local entry = __Anita.variables:Get(name)
        if entry == nil then
            return nil
        elseif entry.type == Anita.VariableType.Boolean then
            return toboolean(entry.value)
        elseif entry.type == Anita.VariableType.Number then
            return tonumber(entry.value)
        else -- entry.type == Anita.VariableType.String
            return entry.value
        end
    else
        if type(value) == 'boolean' then
            __Anita.variables:Set(name, Anita.VariableType.Boolean, tostring(value))
        elseif type(value) == 'number' then
            __Anita.variables:Set(name, Anita.VariableType.Number, tostring(value))
        elseif type(value) == 'string' then
            __Anita.variables:Set(name, Anita.VariableType.String, value)
        else
            warn('Variable can only be boolean, number, or string, but found ' .. tostring(value))
        end
    end
end

-- global variable
function gv(name, value)
    if value == nil then
        local entry = __Anita.checkpointHelper:GetGlobalVariable(name)
        if entry == nil then
            return nil
        elseif entry.type == Anita.VariableType.Boolean then
            return toboolean(entry.value)
        elseif entry.type == Anita.VariableType.Number then
            return tonumber(entry.value)
        else -- entry.type == Anita.VariableType.String
            return entry.value
        end
    else
        if type(value) == 'boolean' then
            __Anita.checkpointHelper:SetGlobalVariable(name, Anita.VariableType.Boolean, tostring(value))
        elseif type(value) == 'number' then
            __Anita.checkpointHelper:SetGlobalVariable(name, Anita.VariableType.Number, tostring(value))
        elseif type(value) == 'string' then
            __Anita.checkpointHelper:SetGlobalVariable(name, Anita.VariableType.String, value)
        else
            warn('Variable can only be boolean, number, or string, but found ' .. tostring(value))
        end
    end
end

-- temporary variable, not saved in checkpoints, not calculated in varables hash
local tv_storage = {}

function tv(name, value)
    if value == nil then
        return tv_storage[name]
    else
        tv_storage[name] = value
    end
end
