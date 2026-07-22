using System;
using System.Collections.Generic;

public class IncidentManager
{
    private List<SecurityIncident> _incidents;
    private List<ResponseResult> _results;
    private SecurityAnalyst _analyst;

    public IncidentManager()
    {
        _incidents = new List<SecurityIncident>();
        _results = new List<ResponseResult>();
        _analyst = new SecurityAnalyst("Unknown");

        CreateIncidents();
    }

    private void CreateIncidents()
    {
        CreatePhishingIncidents();
        CreateMalwareIncidents();
        CreateBruteForceIncidents();
    }

    private void CreatePhishingIncidents()
    {
        _incidents.Add(new PhishingIncident(
            "An employee entered their password into a suspicious login page.",
            100,
            new List<string>
            {
                "Ignore the report",
                "Reset the employee's password and investigate",
                "Delete the employee's account",
                "Shut down the entire company network"
            },
            2,
            "The password may have been stolen. Resetting it and investigating the message helps protect the account."
        ));

        _incidents.Add(new PhishingIncident(
            "An employee receives an unexpected invoice attachment from an unknown company.",
            100,
            new List<string>
            {
                "Open the attachment to see what it contains",
                "Forward it to every employee",
                "Report the message without opening the attachment",
                "Reply with company payment information"
            },
            3,
            "Unexpected attachments should not be opened. The message should be reported so the security team can investigate it."
        ));

        _incidents.Add(new PhishingIncident(
            "An email claiming to be from the company president asks an employee to urgently purchase gift cards.",
            100,
            new List<string>
            {
                "Purchase the gift cards immediately",
                "Verify the request through a separate communication method",
                "Reply with the employee's password",
                "Forward the email to customers"
            },
            2,
            "Urgent gift-card requests are a common phishing technique. The request should be verified through a trusted method."
        ));

        _incidents.Add(new PhishingIncident(
            "An employee receives several MFA approval notifications they did not request.",
            100,
            new List<string>
            {
                "Approve the notifications to make them stop",
                "Ignore them and continue working",
                "Turn off MFA permanently",
                "Deny them, change the password, and report the activity"
            },
            4,
            "Unexpected MFA requests may mean an attacker has the password. The requests should be denied and the account secured."
        ));
    }

    private void CreateMalwareIncidents()
    {
        _incidents.Add(new MalwareIncident(
            "An employee's computer is opening unknown programs and running very slowly.",
            100,
            new List<string>
            {
                "Continue using the computer",
                "Delete random files",
                "Disconnect it from the network and report it",
                "Send suspicious files to coworkers"
            },
            3,
            "Disconnecting the computer can prevent malware from spreading while the security team investigates."
        ));

        _incidents.Add(new MalwareIncident(
            "A computer displays a message saying its files have been encrypted and money must be paid.",
            100,
            new List<string>
            {
                "Immediately pay the attacker",
                "Isolate the computer and contact the incident-response team",
                "Restart every company computer",
                "Post the ransom message online"
            },
            2,
            "The computer should be isolated to prevent ransomware from spreading. The incident-response team should be contacted."
        ));

        _incidents.Add(new MalwareIncident(
            "An employee finds an unknown USB drive in the company parking lot.",
            100,
            new List<string>
            {
                "Plug it into a work computer",
                "Take it home and open it",
                "Give it to another employee",
                "Give it to the security team without plugging it in"
            },
            4,
            "Unknown USB drives may contain malware. They should never be connected to a company computer."
        ));

        _incidents.Add(new MalwareIncident(
            "A browser suddenly begins showing constant pop-ups and redirecting to unknown websites.",
            100,
            new List<string>
            {
                "Disconnect the computer and run an approved security scan",
                "Click every pop-up to close it",
                "Enter company credentials into the pop-ups",
                "Ignore the problem"
            },
            1,
            "Unexpected redirects and pop-ups may indicate malware. Disconnecting and scanning the computer is the safest response."
        ));
    }

    private void CreateBruteForceIncidents()
    {
        _incidents.Add(new BruteForceIncident(
            "The login system reports hundreds of failed attempts against an administrator account.",
            100,
            new List<string>
            {
                "Ignore the login attempts",
                "Post the password online",
                "Temporarily disable the account and investigate",
                "Give the account more permissions"
            },
            3,
            "Temporarily disabling the account can stop the attack while the login attempts are investigated."
        ));

        _incidents.Add(new BruteForceIncident(
            "A single IP address is repeatedly attempting to log into the same employee account.",
            100,
            new List<string>
            {
                "Give the IP address the password",
                "Block the IP address and review the login logs",
                "Remove the employee's account permanently",
                "Turn off all security logging"
            },
            2,
            "Blocking the suspicious IP can stop the immediate attack. Reviewing logs helps determine what happened."
        ));

        _incidents.Add(new BruteForceIncident(
            "Many employee accounts are receiving repeated failed login attempts.",
            100,
            new List<string>
            {
                "Disable all passwords",
                "Ignore the attempts",
                "Make every password the same",
                "Enable rate limiting, account lockouts, and MFA"
            },
            4,
            "Rate limiting, lockout rules, and MFA make automated password attacks more difficult."
        ));

        _incidents.Add(new BruteForceIncident(
            "An account successfully logs in from another country after hundreds of failed attempts.",
            100,
            new List<string>
            {
                "Revoke active sessions, reset the password, and investigate",
                "Give the account administrator access",
                "Ignore the successful login",
                "Delete all login records"
            },
            1,
            "The successful login may indicate that the password was compromised. Sessions should be revoked and the account secured."
        ));
    }

    public void Run()
    {
        DisplayWelcome();

        Console.Write("Enter your analyst name: ");
        string name = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(name))
        {
            name = "Unknown Analyst";
        }

        bool playAgain;

        do
        {
            // Reset the results and score before every game.
            _results.Clear();
            _analyst = new SecurityAnalyst(name);

            Console.WriteLine();
            Console.WriteLine($"Welcome, {_analyst.GetName()}!");
            Console.WriteLine(
                $"You will respond to {_incidents.Count} cybersecurity incidents.");
            Console.WriteLine();

            foreach (SecurityIncident incident in _incidents)
            {
                RunIncident(incident);
            }

            PerformanceReport report = new PerformanceReport();

            report.DisplayReport(
                _analyst,
                _results,
                GetMaximumScore());

            playAgain = AskToPlayAgain();

            if (playAgain)
            {
                Console.Clear();
                DisplayWelcome();
            }

        } while (playAgain);

        Console.WriteLine();
        Console.WriteLine("Thank you for using the simulator!");
    }

    private void DisplayWelcome()
    {
        Console.WriteLine("======================================");
        Console.WriteLine("  CYBERSECURITY INCIDENT SIMULATOR");
        Console.WriteLine("======================================");
        Console.WriteLine();
    }

    private void RunIncident(SecurityIncident incident)
    {
        Console.WriteLine("--------------------------------------");
        Console.WriteLine(incident.GetIncidentType());
        Console.WriteLine("--------------------------------------");

        Console.WriteLine(incident.GetDescription());
        Console.WriteLine();

        incident.DisplayOptions();

        int response = GetValidResponse();

        bool wasCorrect = incident.CheckResponse(response);
        int pointsEarned = 0;

        Console.WriteLine();

        if (wasCorrect)
        {
            pointsEarned = incident.GetPointValue();
            _analyst.AddPoints(pointsEarned);

            Console.WriteLine("Correct response!");
            Console.WriteLine($"You earned {pointsEarned} points.");
        }
        else
        {
            Console.WriteLine("Incorrect response.");
            Console.WriteLine("You earned 0 points.");
        }

        Console.WriteLine();
        Console.WriteLine($"Explanation: {incident.GetExplanation()}");
        Console.WriteLine();

        ResponseResult result = new ResponseResult(
            incident.GetIncidentType(),
            wasCorrect,
            pointsEarned,
            incident.GetExplanation());

        _results.Add(result);
    }

    private int GetValidResponse()
    {
        int response;
        bool validResponse = false;

        do
        {
            Console.Write("Enter your response (1-4): ");
            string input = Console.ReadLine() ?? "";

            bool isNumber = int.TryParse(input, out response);

            if (isNumber && response >= 1 && response <= 4)
            {
                validResponse = true;
            }
            else
            {
                Console.WriteLine(
                    "Please enter a number from 1 through 4.");
            }

        } while (!validResponse);

        return response;
    }

    private int GetMaximumScore()
    {
        int maximumScore = 0;

        foreach (SecurityIncident incident in _incidents)
        {
            maximumScore += incident.GetPointValue();
        }

        return maximumScore;
    }

    private bool AskToPlayAgain()
    {
        while (true)
        {
            Console.WriteLine();
            Console.Write("Would you like to play again? (yes/no): ");

            string answer = Console.ReadLine() ?? "";
            answer = answer.Trim().ToLower();

            if (answer == "yes" || answer == "y")
            {
                return true;
            }
            else if (answer == "no" || answer == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine(
                    "Please enter yes or no.");
            }
        }
    }
}