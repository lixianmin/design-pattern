
---

#### Logging Decorator —static language : C++

```cpp
class LoggedGameState : public GameState
{
    public:
        LoggedState(State &wrapped): _wrapped(wrapped) {}
        virtual void OnEnter ()
        {
            log ("Begin: OnEnter()");
            _wrapped.OnEnter();
            log ("End: OnEnter()");
        }
        virtual void OnExit ()
        {
            log ("Begin: OnExit()");
            _wrapped.OnExit();
            log ("End: OnExit()");
        }
    private:
        GameState &_wrapped;
};

void EnableGameStateLogging ()
{
    GameState *state = new LoggedGameState(Locator::GetGameState());
    Locator::Provide(state); // swap it in.
}
```

---

#### 

#### Logging Decorator -- dynamic language: lua

```lua
function This:EnableLog (klass)
    for name, method in pairs(klass) do
        if type(method) == 'function' then
            klass[name] = function (...)
                print ('Begin:', name)
                method(...)
                print ('End:', name)
            end
        end
    end
end
```

---

#### Array snapshot

```java
class PlayerManager
{
    public void AddPlayer (int id, Player player)
    [
        _players.Add(id, player);
    }

    public void Update ()
    [
        if (_capacity != _players.Capacity)
        {
            _capacity = _players.Capacity;
            _snapshot = new Player[_capacity];
        }

        int count = _players.Count;
        Array.Copy(_players.Values, _snapshot, count);

        for (int i= 0; i< count; ++i)
        {
            _snapshot[i].Update();
        }               
    }

    private readonly SortedTable<int, Player> _players = new SortedTable<int, Player>();
    private Player[] _snapshot = new Player[0];
    private int _capacity;
}
```



