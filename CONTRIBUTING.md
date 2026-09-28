# Contributing to CopilotBuddy

CopilotBuddy is a port of Honorbuddy to WoW 3.3.5a (build 12340). Pull requests are welcome when they follow these rules. PRs that don't will be closed.

## Pull requests

1. **Follow Honorbuddy.** A fix must reproduce what the original HB code does at the same place: HB 3.3.5a first, then HB 4.3.4, or a later HB version (5.x/6.x) that fixed the same bug itself. Name the HB version and method you copied in the PR. Behavior that no HB version has is not merged, unless it fixes code the port added itself.
2. **Test in game before opening the PR.** Run the change on a 3.3.5a server and attach the log (Logs folder) that shows the problem before and the fix after. Untested PRs are closed.
3. **No code comments.** Only the original HB comments are kept.
4. **One fix per PR.** Keep it small, built against current master with 0 errors.
5. **Don't break other code.** The bots, plugins, routines, quest behaviors and dungeon scripts in the bin folder are compiled at runtime. If you change a public method, fix or check every caller there too.

## Bug reports

Open an issue with the full log, what happened, what you expected, and the profile or bot you used.
